
using RPGgame.Modules.Items.Props;

namespace RPGgame.Modules.Entitys
{
    internal class MainEquipments
    {
        private Weapon mainWeapon;
        private Clothes[] clothes;

        public MainEquipments()
        {
            clothes = new Clothes[3]; 
        }

        public bool CheckEquipmentsById(int id)
        {
            if (mainWeapon.Id == id)
            {
                return true;
            }
            for (int i = 0; i < clothes.Length; i++)
            {
                if (clothes[i].Id == id)
                {
                    return true;
                }
            }

            return false;
        }

        public Clothes SwapArmor(Clothes armor)
        {
            Clothes curArmor = clothes[(int)armor.GetTypeArmor()];
            clothes[(int)armor.GetTypeArmor()] = armor;
            return curArmor;
        }

        public Weapon SwapWeapon(Weapon weapon)
        {
            Weapon curWeapon = mainWeapon;
            mainWeapon = weapon;
            return curWeapon;
        }

        public Clothes GetArmor(TypeArmor type)
        {
            return clothes[(int)type];
        }

        public Weapon GetWeapon()
        {
            return mainWeapon;
        }

        public Clothes PopArmor(TypeArmor type)
        {
            Clothes clt = clothes[(int)type];
            clothes[(int)type] = null;
            return clt;
        }

        public Weapon PopWeapon()
        {
            Weapon weapon = mainWeapon;
            mainWeapon = null;
            return weapon;
        }
    }
}
