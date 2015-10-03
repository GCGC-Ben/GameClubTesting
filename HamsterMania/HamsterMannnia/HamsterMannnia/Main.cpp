
#include <SFML/Graphics.hpp>
#include <iostream>
#include <time.h>
#include <vector>
#include "ParticleManager.h"


static double FPS;
static double secondsFPS;
static double oldTime; 

using namespace sf;

bool update()
{
	clock_t timer;
	timer = clock();

	double nTime = timer - oldTime;
	if (nTime > 600)
	{
		std::cout <<"Update FPS:"<< FPS << "\n";
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

	return true;
}

bool draw(RenderWindow& window)
{
	window.clear();
	//put draw code below;
	ParticleManager::draw(window);

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
		
		Vector2f pos(rand() % 100 + Mouse::getPosition().x - 50, rand() % 100 + Mouse::getPosition().y - 50);

		ParticleManager::add(pos);

		draw(window);
	}

	return 0;
}

