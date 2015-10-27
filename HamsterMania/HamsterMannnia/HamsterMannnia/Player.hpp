#pragma once

#include <SFML/Graphics.hpp>
#include <SFML/System/Vector2.hpp>

#include <cmath> 

class Player {
    private:
        // const vars
        const float FRICTION   = 0.005;
        const float ROTATE     = (std::atan(1) * 4) / 256; // (pi / 32);
        const float ELASTICITY = 0.85;
        
        // player vars
        float mass;
         
        // draw vars
        static sf::Texture texture;
        sf::Sprite sprite;

        // vars that determine launch distance
        float charge, facing_direction;

        // vars set by recalibrate methods
        float movement_direction, movement_magnitude;

        // vectors (float type)
        sf::Vector2f position_vector, movement_vector, charged_vector;
        
        // key bindings
        std::map<char, sf::Keyboard::Key> keyBindings;

        /*
            Handles the keyboard input.
            Determines which keys are pressed and modifies movement vars accordingly.
        */
        void controls();

        
        /*
            Handles movement
            Friction, charge-released, and finally, movement
        */
        void movement();
        
        
        /*
            Reset direction of movement if player is going to move
        */
        void recalibrate_direction();
        
        /*
            Reset the speed of movement if player is about to move
        */
        void recalibrate_magnitude();
        
        
        /*
            Changes x and y of given vector to new values
            Takes the vector to change, and the magnitude and direction to change it to
        */
        void change_vector_vals(sf::Vector2f& vec, float magnitude, float rads);
        
        
    public:    
        // if Player's load() has been called yet
        static bool loaded;

        /*
            Constructer 
        */
        Player();
        Player(float _mass, sf::Vector2f& _position_vector);
        Player(float _mass, sf::Vector2f& _position_vector, sf::Keyboard::Key _up, sf::Keyboard::Key _left, sf::Keyboard::Key _right);


        /*
            Get stuff yay
        */
        sf::Vector2f get_position();

        float get_mass();

        std::map<char, sf::Keyboard::Key> get_key_bindings();
        
        /*
            Set stuff yay
        */
        void set_mass(float _mass); 
        
        void set_position(sf::Vector2f& _position_vector);
        
        void set_key_binding(char key_to_set, sf::Keyboard::Key _key);
        
        /*
            LOAD
        */
        static void load();
        
        /*
            DRAW
        */
        void draw(sf::RenderWindow& render_window);
        
        /*
            Make the spite thing (must call after loading)
        */
        void make_sprite(); 
        
        /*
            UPDATE
        */
        void update();


        /*
            Handles collision
            Does physics magic
        */
        void collision(Player&, Player&);
};
