#include <SFML/Audio.hpp>
#include <SFML/Graphics.hpp>
#include <string>
#include <iostream>
#include <vector>

int main()
{
	sf::RenderWindow window(sf::VideoMode(200, 200), "SFML works!");
	sf::CircleShape shape(100.f);
	shape.setFillColor(sf::Color::Green);



	sf::SoundBuffer buffer;
	if (!buffer.loadFromFile("demon child event.wav"))
		std::cout << "Failed to load \"demon child event.wav\"" << std::endl;
	sf::Sound demon;
	demon.setBuffer(buffer);

	sf::SoundBuffer juan;
	if (!juan.loadFromFile("cat swipe effect.wav"))
		std::cout << "Failed to load \"cat swipe effect.wave\"" << std::endl;
	sf::Sound swipe;
	swipe.setBuffer(juan);

	sf::SoundBuffer juandeagle;
	if (!juandeagle.loadFromFile("death sfx.wav"))
		std::cout << "Failed to load \"death sfx.wav\"" << std::endl;
	sf::Sound death;
	death.setBuffer(juandeagle);

	sf::SoundBuffer ju;
	if (!ju.loadFromFile("collision sfx.wav"))
		std::cout << "Failed to load \"collision sfx.wav\"" << std::endl;
	sf::Sound collision;
	collision.setBuffer(ju);

	sf::SoundBuffer blackout;
	if (!blackout.loadFromFile("lightning blackout event.wav"))
		std::cout << "Failed to load \"lightning blackout event.wav\"" << std::endl;
	sf::Sound lightning;
	lightning.setBuffer(blackout);

	sf::SoundBuffer whatrthose;
	if (!whatrthose.loadFromFile("hm victory song.wav"))
		std::cout << "Failed to load \"hm victory song\"" << std::endl;
	sf::Sound victory;
	victory.setBuffer(whatrthose);

	sf::SoundBuffer damnSon;
	if (!damnSon.loadFromFile("hm menu music.wav"))
		std::cout << "Failed to load \"hm menu music.wav\"" << std::endl;
	sf::Sound menu;
	menu.setBuffer(damnSon);
	menu.play();
	menu.setLoop(true);

	sf::SoundBuffer pentakill;
	if (!pentakill.loadFromFile("hm defeat music.wav"))
		std::cout << "Failed to load \"hm defeat music.wav\"" << std::endl;
	sf::Sound defeat;
	defeat.setBuffer(pentakill);

	sf::SoundBuffer waifu;
	if (!waifu.loadFromFile("hm battle music.wav"))
		std::cout << "Failed to load \"hm battle music.wav\"" << std::endl;
	sf::Sound battle;
	battle.setBuffer(waifu);
	
	while (window.isOpen())
	{
		sf::Event event;
		while (window.pollEvent(event))
		{
			if (event.key.code == sf::Keyboard::Q)
			{
				menu.pause();
				battle.setVolume(60);
				battle.play();
				battle.setLoop(true);
			}
			if (event.key.code == sf::Keyboard::W)
			{
				battle.pause();
				demon.play();
			}
			if (event.key.code == sf::Keyboard::A) // idk insert here when demon baby event ends
					battle.play();
			
			if (event.key.code == sf::Keyboard::E)
				swipe.play();
			if (event.key.code == sf::Keyboard::R)
				death.play();
			if (event.key.code == sf::Keyboard::T)
				collision.play();
			if (event.key.code == sf::Keyboard::Y)
			{
				battle.pause();
				lightning.play();
			}
			if (event.key.code == sf::Keyboard::U)
				battle.play(); //when lightning blackout event stops

			if (event.key.code == sf::Keyboard::I)
				lightning.stop();
			if (event.key.code == sf::Keyboard::O)
			{
				battle.stop();
				lightning.stop();
				swipe.stop();
				collision.stop();
				demon.stop();

				victory.play();
			}
			if (event.key.code == sf::Keyboard::P)
			{
				battle.stop();
				lightning.stop();
				swipe.stop();
				collision.stop();

				defeat.play();
			}
			if (event.type == sf::Event::Closed)
				window.close();

		}

	}	window.clear();
			window.draw(shape);
			window.display();

		
			return 0;

		}