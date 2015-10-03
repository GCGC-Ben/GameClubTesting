#pragma once
#include <SFML/Graphics.hpp>
#include <vector>

using namespace sf;

class ParticleManager
{
	static Texture circletxt;
	static std::vector < Sprite >allTxts;
	
public:
	static void load();
	static void draw(RenderWindow& window);
	static void update();
	static void add(Vector2f pos);
};

