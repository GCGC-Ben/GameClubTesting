
#include <SFML/Graphics.hpp>
#include <iostream>
#include <time.h>

static int FPS;
static double secondsFPS;
static double oldTime; 

using namespace sf;

bool update()
{
	time_t timer;
	time(&timer);
	secondsFPS = timer -oldTime;

	if (secondsFPS > 1)
	{
		std::cout <<"Update FPS:"<< FPS<<"\n";
		oldTime = timer;
		FPS = 0;
	}
	FPS++;

	if (FPS == 60)
	{
		Time t = seconds(2 - secondsFPS);
		sleep(t);
	}
	
	//put update code below



	return true;
}

bool draw(RenderWindow &window)
{
	window.clear();
	//put draw code below;
		sf::CircleShape shape(100.f);
	shape.setFillColor(sf::Color::Green);
	window.draw(shape);

	//keep this at bottem
	window.display();
	return true;
}



int main()
{
	FPS = 0;
	time_t timer;
	time(&timer);
	oldTime = timer;

	sf::RenderWindow window(sf::VideoMode(1280,  720), "HamsterMain");

	enum GameState {Menu,Arena,Paused};
	GameState cgs = Arena;

	while (window.isOpen())
	{
		sf::Event event;
		while (window.pollEvent(event))
		{
			if (event.type == sf::Event::Closed)
				window.close();
		}

		update();
		draw(window);
	}

	return 0;
}

