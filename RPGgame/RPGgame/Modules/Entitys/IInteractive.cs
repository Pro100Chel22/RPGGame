using RPGgame.Modules.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Modules.Entitys
{
    internal interface IInteractive
    {
        MainEquipments GetMainEquipments();
        Behaviour GetBehaviour();
        Storage GetInventory();
        bool IsAlive();
        int GetMoney();
        void SetMoney(int money);
    }
}
