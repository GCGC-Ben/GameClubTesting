#include <SFML/Graphics.hpp>
#include <SFML/System/Vector2.hpp>

#include "Player.hpp"

#include <cmath> 
#include <iostream>

using namespace sf;
  
  
/******* PLAYER CLASS TIME ********/

/*
    Constructer 
*/
Player::Player(float _mass, Vector2f& _position_vector, Keyboard::Key _up, Keyboard::Key _left, Keyboard::Key _right) {
    // initialize loaded
    loaded = false;
    
    // initialize player vars
    mass          = _mass;
    
    // initialize vars that determine launch distance
    charge = facing_direction = 0;

    // initialize vars set by recalibrate methods
    movement_direction = movement_magnitude = 0;

    // initialize vectors (float type)
    position_vector = Vector2f(_position_vector);
    movement_vector = Vector2f(0.f, 0.f);
    charged_vector  = Vector2f(0.f, 0.f);
    
    // set key bindings
    // -- would have to be modified for controller functionality
    // -- would also have to modify controls()
	keyBindings = decltype(keyBindings){
        { 'U', _up},   // up
        { 'L', _left}, // left
        { 'R', _right} // right
    };
}



bool Player::loaded;
Texture Player::texture;
/*
    Get stuff yay
*/
Vector2f Player::get_position() {
    return position_vector;
}

float Player::get_mass() {
    return mass;
}

std::map<char, Keyboard::Key> Player::get_key_bindings() {
    return keyBindings;
}

/*
    Set stuff yay
*/
void Player::set_mass(float _mass) {
    mass = _mass;
}

void Player::set_position(Vector2f& _position_vector) {
    position_vector.x = _position_vector.x;
    position_vector.y = _position_vector.y;
}

void Player::set_key_binding(char key_to_set, Keyboard::Key _key) {
    keyBindings[key_to_set] = _key;
}


/*
    LOAD
*/
void Player::load() {
    // make texture
    if(!texture.loadFromFile("theBestPicture.png")) {
        //do error things
        std::cout << "Error loading theBestPicture texture" << std::endl;
    } else 
        loaded = true;
        
    texture.setSmooth(true);
}

/*
    DRAW
*/
void Player::draw(RenderWindow& render_window) {
    render_window.draw(sprite, transform);
}

/*
    Make the spite thing (must call after loading)
*/
void Player::make_sprite() {
    if(loaded)
        sprite.setTexture(texture);
    else
        std::cout << "Error: initializing sprite before load method called (no texture)" << std::endl;
}

/*
    UPDATE
*/
void Player::update() {
    controls();
    movement();
    sprite.setPosition(position_vector);
    transform.rotate(facing_direction * (180 / (std::atan(1) * 4)));
}


/*
    Handles collision
    Does physics magic
*/
void Player::collision(Player& p1, Player& p2) {
    Vector2f rVelo  = p2.movement_vector - p1.movement_vector;
    Vector2f normal = p1.position_vector - p2.position_vector;
    float e         = std::min(p1.ELASTICITY, p2.ELASTICITY);   // takes the smaller of the two elasticities
    float veloAroundNormal = normal.x * rVelo.x + normal.y * rVelo.y; // using dot product on the relative velocities

    float modify = (-(1+e) * veloAroundNormal) / ((1/p1.mass) + (1/p2.mass));  //this physics magic.  This value to determine the impluse. 

    Vector2f impluse;  // this is the impluse this will be what we use for modification.
    impluse.x = normal.x * modify;
    impluse.y = normal.y * modify;


    // this is the actual seeing of the vectors
    p1.movement_vector.x -= impluse.x *(1/p1.mass);
    p1.movement_vector.y -= impluse.y *(1/p1.mass);
    p2.movement_vector.x -= impluse.x *(1/p2.mass);
    p2.movement_vector.y -= impluse.y *(1/p2.mass);


    // these are the recalibrate calls and the charge geting shut off. 
    p1.recalibrate_direction();
    p1.recalibrate_magnitude();
    p1.charge = 0;

    p2.recalibrate_direction();
    p2.recalibrate_magnitude();
    p2.charge = 0;
}


/*
    Handles the keyboard input.
    Determines which keys are pressed and modifies movement vars accordingly.
*/
void Player::controls() {
    // handle charge input
    if(Keyboard::isKeyPressed(keyBindings['U']))
        charge += 0.05;
    
    // handle directional input
    if(Keyboard::isKeyPressed(keyBindings['L'])) {
        // face hamster in direciton of rotation, then if it's still not all the way there, move it a little more
        facing_direction -= ROTATE;
        if(!movement_magnitude && facing_direction != movement_magnitude)
            facing_direction -= ROTATE;
            
        // change the actual movement direction 
        if(movement_magnitude)
            movement_direction -= ROTATE / ((movement_magnitude + 0.05) / 2);
    }

    if(Keyboard::isKeyPressed(keyBindings['R'])) {
        // face hamster in direciton of rotation, then if it's still not all the way there, move it a little more            
        facing_direction += ROTATE;
        if(!movement_magnitude && facing_direction != movement_direction)
            facing_direction += ROTATE;
            
        // change the actual movement direction
        if(movement_magnitude)
            movement_direction += ROTATE / ((movement_magnitude + 0.05) / 2);
    }
}


/*
    Handles movement
    Friction, charge-released, and finally, movement
*/
void Player::movement() {
    // handle friction
    if((movement_magnitude - FRICTION) > 0)
        movement_magnitude -= FRICTION;
    else
        movement_magnitude = 0;
        
    // add calculated magnitude and direction to movement vector
    change_vector_vals(movement_vector, movement_magnitude, movement_direction);
    
    // if they launch, add charge vector to movement vector, then recalibrate
    if(charge) { 
        // change charge vector and add that to movement
        change_vector_vals(charged_vector, charge, facing_direction);
        movement_vector += charged_vector;
        
        // recalibrate direction and magnitude, then reset charge
        recalibrate_direction();
        recalibrate_magnitude();
        charge = 0; 
    }
    
    // add finished movement vector to current position
    position_vector += movement_vector;
}

/*
    Reset direction of movement if player is going to move
*/
void Player::recalibrate_direction() {
    if(movement_vector.x)
        movement_direction = std::acos(movement_magnitude / movement_vector.x);
    else if(movement_vector.y)
        movement_direction = std::asin(movement_magnitude / movement_vector.y); 
}

/*
    Reset the speed of movement if player is about to move
*/
void Player::recalibrate_magnitude() {
    // Pythagorean's theorum yay, only if they're going to move  
    if(!movement_vector.x && !movement_vector.y)
        movement_magnitude = std::sqrt( std::pow(movement_vector.x, 2) + std::pow(movement_vector.y, 2) );
}


/*
    Changes x and y of given vector to new values
    Takes the vector to change, and the magnitude and direction to change it to
*/
void Player::change_vector_vals(Vector2f& vec, float magnitude, float rads) {
    vec.x = magnitude * std::cos(rads) * (1/mass);
    vec.y = magnitude * std::cos(rads) * (1/mass);
}
