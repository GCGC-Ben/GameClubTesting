
#include <SFML/Graphics.hpp>
#include <iostream>
#include <time.h>
#include <vector>
#include "ParticleManager.h"
#include "Player.hpp"

static double FPS;
static double secondsFPS;
static double oldTime; 
//Player p1(1, Vector2f(10, 10), sf::Keyboard::Up, sf::Keyboard::Left, sf::Keyboard::Right);

using namespace sf;

bool update()
{
	clock_t timer;
	timer = clock();

	double nTime = timer - oldTime;
	if (nTime > 600)
	{
		if (FPS < 50)
		{
			std::cout << "LOW FPS" << FPS << "\n";
		}
		oldTime = timer;
		FPS = 0;
	}
	
	FPS++;

	if (nTime < (FPS * 10))
	{
		Time t = milliseconds((FPS * 10)-nTime);
		sleep(t);
	}



	//put update code below
	ParticleManager::update();
	//p1.update();

	return true;
}

bool draw(RenderWindow& window)
{
	window.clear();
	//put draw code below;
	ParticleManager::draw(window);
	//p1.draw(window);
	//keep this at bottem
	window.display();
	return true;
}



int main()
{
	FPS = 0;
	clock_t timer;
	timer = clock();
	oldTime = timer;

	RenderWindow window(sf::VideoMode(1280,  720), "HamsterMaina");

	enum GameState {Menu,Arena,Paused};
	GameState cgs = Arena;
	//load methods here
	ParticleManager::load();
	//Player::load();
	//p1.make_sprite();
	//load methods above
	while (window.isOpen())
	{
		sf::Event event;
		while (window.pollEvent(event))
		{
			if (event.type == sf::Event::Closed)
				window.close();
		}

		update();
		
		Vector2f pos(rand() % 100 + Mouse::getPosition().x - 200, rand() % 100 + Mouse::getPosition().y - 200);

		ParticleManager::add(pos, Color(rand() % 255, rand() % 255, rand() % 255, 255));

		Vector2f pos2(rand() % 100 + Mouse::getPosition().x - 200, rand() % 100 + Mouse::getPosition().y - 200);

		ParticleManager::add(pos2, Color(rand() % 255, rand() % 255, rand() % 255, 255));

		draw(window);
	}

	return 0;
}

