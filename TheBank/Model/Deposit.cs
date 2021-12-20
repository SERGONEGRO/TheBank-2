using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank2.Model
{
    class Deposit
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        public int ClientId { get; set; }
        /// <summary>
        /// Вкладчик
        /// </summary>
        public virtual Client Client { get; set; }

        /// <summary>
        /// Процент вклада
        /// </summary>
        public double DepositPercent { get; set; }

        /// <summary>
        /// Начальная сумма вклада
        /// </summary>
        public int StartSum { get; set; }

        /// <summary>
        /// Есть ли капитализация процентов?
        /// </summary>
        public bool IsCapitalized { get; set; }

        /// <summary>
        /// Текущая сумма
        /// </summary>
        public double CurrentSum { get; set; }

        /// <summary>
        /// Дата начала вклада
        /// </summary>
        public DateTime DateOfStart { get; set; }


        /// <summary>
        /// количество месяцев вклада
        /// </summary>
        public int MonthsCount { get; set; }

        /// <summary>
        /// Дата окончания вклада
        /// </summary>
        public DateTime DateOfEnd
        {
            get
            {
                return DateOfStart.AddMonths(MonthsCount);
            }
        }

        public int ResponsibleEmployeeId { get; set; }
        /// <summary>
        /// Ответственный сотрудник
        /// </summary>
        public virtual User ResponsibleEmployee { get; set; }

        /// <summary>
        /// свойство ищущее ответственного сотрудника, привязанного к данному депозиту
        /// </summary>
        [NotMapped]
        public User DepositUser
        {
            get
            {
                return DataWorker.GetUserByResponsibleEmployeeId(ResponsibleEmployeeId);
            }
        }
        /// <summary>
        /// свойство ищущее клиента данного депозита
        /// </summary>
        [NotMapped]
        public Client DepositClient
        {
            get
            {
                return DataWorker.GetClientByClientId(ClientId);
            }
        }
    }
}

