using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank2.Model
{
    class User:Person
    {
        #region Свойства
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        /// <summary>
        /// Ставка
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// Количество отработанных часов
        /// </summary>
        public int Hours { get; set; }

        /// <summary>
        /// Производит расчет заработной платы и возвращает ее
        /// </summary>
        /// <returns></returns>
        //public abstract float GetWage();


        #endregion
    }
}
