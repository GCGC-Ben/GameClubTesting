#include <SFML/Graphics.hpp>
#include <iostream>
#include <SFML/Window.hpp>
#include <SFML/OpenGL.hpp>
#include "ParticleManager.h"
#include <vector>

using namespace sf;

Texture ParticleManager::circletxt;
std::vector<Sprite> ParticleManager::allTxts;

	void ParticleManager:: load()
	{
		if (!circletxt.loadFromFile("Content\\base cirlce.png"))
		{
			std::cout << "Failed to load Base circle.png\n";
		}
		else
		{
			std::cout << "loaded base circle.png\n";
		}
	
	}

	void ParticleManager::update()
	{

	}

	void ParticleManager::add(Vector2f pos)
	{
		if (allTxts.size() > 100)
		{
			allTxts.erase(allTxts.begin());
		}

		Sprite s;
		s.setTexture(circletxt);
		s.setPosition(pos);
		allTxts.push_back(s);
	}

	void ParticleManager::draw(sf::RenderWindow& window)
	{
		for (int i = 0; i < allTxts.size(); i++)
		{
			window.draw(allTxts[i]);
		}
	}



