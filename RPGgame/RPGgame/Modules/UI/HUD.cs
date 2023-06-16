
using RPGgame.Modules.Entitys;
using SFML.Graphics;
using SFML.System;

namespace RPGgame.Modules.UI
{
    internal class HUD
    {
        public bool IsActive { get; set; }
        private Entity player;
        private int maxHp;
        private int maxEndurance;

        RectangleShape shapeOutlineHealth;
        RectangleShape shapeHealth;
        RectangleShape shapeOutlineEndurance;
        RectangleShape shapeEndurance;
        RectangleShape shapeOutlineResistance;
        RectangleShape shapeResistance;

        public HUD(Entity player) 
        {
            this.player = player;
            IsActive = true;
            maxHp = player.GetBehaviour().GetCharacteristics().maxHealth;
            maxEndurance = player.GetBehaviour().GetCharacteristics().maxEndurance;

            shapeOutlineHealth = new RectangleShape();
            shapeOutlineHealth.Size = new Vector2f(200.0f, 40.0f);
            shapeOutlineHealth.Position = new Vector2f(5.0f, 5.0f);
            shapeOutlineHealth.OutlineThickness = 1;
            shapeOutlineHealth.FillColor = Color.Transparent;

            shapeHealth = new RectangleShape();
            shapeHealth.Position = new Vector2f(5.0f, 5.0f);
            shapeHealth.FillColor = Color.Red;

            shapeOutlineEndurance = new RectangleShape();
            shapeOutlineEndurance.Size = new Vector2f(200.0f, 40.0f);
            shapeOutlineEndurance.Position = new Vector2f(5.0f, 50.0f);
            shapeOutlineEndurance.OutlineThickness = 1;
            shapeOutlineEndurance.FillColor = Color.Transparent;

            shapeEndurance = new RectangleShape();
            shapeEndurance.Position = new Vector2f(5.0f, 50.0f);
            shapeEndurance.FillColor = Color.Blue;

            shapeOutlineResistance = new RectangleShape();
            shapeOutlineResistance.Size = new Vector2f(200.0f, 40.0f);
            shapeOutlineResistance.Position = new Vector2f(5.0f, 95.0f);
            shapeOutlineResistance.OutlineThickness = 1;
            shapeOutlineResistance.FillColor = Color.Transparent;

            shapeResistance = new RectangleShape();
            shapeResistance.Position = new Vector2f(5.0f, 95.0f);
            shapeResistance.FillColor = new Color(150, 150, 150);
        }

        public void Draw(RenderWindow renderIn)
        {
            shapeHealth.Size = new Vector2f(200.0f * ((float)player.GetHealth() / (float)maxHp), 40.0f);
            shapeEndurance.Size = new Vector2f(200.0f * ((float)player.GetEndurance() / (float)maxEndurance), 40.0f);
            shapeResistance.Size = new Vector2f(200.0f * ((float)player.GetResistance() / 50.0f), 40.0f);

            renderIn.Draw(shapeOutlineHealth);
            renderIn.Draw(shapeHealth);

            renderIn.Draw(shapeOutlineEndurance);
            renderIn.Draw(shapeEndurance);

            renderIn.Draw(shapeOutlineResistance);
            renderIn.Draw(shapeResistance);
        }
    }
}
