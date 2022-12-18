using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    //определяем интерфейс INameAndCopy. Добавим его реализацию в другие классы
    interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }

}
