using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank2.Model
{
    public class Position
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int MaxNumber { get; set; }
        public List<User> Users { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        /// <summary>
        /// свойство ищущее департмент, к которому привязана позиция
        /// </summary>
        [NotMapped]
        public Department PositionDepartment
        {
            get
            {
                return DataWorker.GetDepartmentById(DepartmentId);
            }
        }
        /// <summary>
        /// свойство ищущее юзеров, привязанных к позиции
        /// </summary>
        [NotMapped]
        public List<User> PositionUsers
        {
            get
            {
                return DataWorker.GetAllUserstByPositionId(Id);
            }
        }

    }
}
