#include <SFML/Graphics.hpp>
#include <iostream>
#include <SFML/Window.hpp>
#include <SFML/OpenGL.hpp>
#include "ParticleManager.h"
#include <vector>
#include "Player.hpp"
using namespace sf;

Texture ParticleManager::circletxt;
std::vector<Sprite> ParticleManager::allTxts;
int ParticleManager::particleLimit;

	void ParticleManager:: load()
	{
		particleLimit = 1000;
		if (!circletxt.loadFromFile("Content\\base circle.png"))
		{
			std::cout << "Failed to load base circle.png\n";
		}
		else
		{
			std::cout << "loaded base circle.png\n";
		}
	
	}

	void ParticleManager::update()
	{
		for (int i = 0; i < allTxts.size(); i++)
		{
			if (allTxts[i].getColor().a > 0)
			{
				allTxts[i].setColor(Color(allTxts[i].getColor().r, allTxts[i].getColor().r, allTxts[i].getColor().b, allTxts[i].getColor().a - 1));
				allTxts[i].setRotation(allTxts[i].getRotation() + 2);
			}
			else
			{
				allTxts.erase(allTxts.begin()+i);
			}
		}
	}

	void ParticleManager::add(Vector2f pos,Color c)
	{
		if (allTxts.size() > particleLimit)
		{
			allTxts.erase(allTxts.begin());
		}

		Sprite s;
		s.setTexture(circletxt);
		s.setPosition(pos);
		s.setColor(c);
		s.setScale((rand() % 50 + 50)/100.0, (rand() % 50 + 50)/100.0);
		allTxts.push_back(s);
	}

	void ParticleManager::add(Vector2f pos)
	{
		add(pos, Color(255, 255, 255, 255));
	}

	void ParticleManager::draw(sf::RenderWindow& window)
	{
		for (int i = 0; i < allTxts.size(); i++)
		{
			window.draw(allTxts[i]);
		}
	}



