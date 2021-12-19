using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBank2.Data;

namespace TheBank2.Model
{
    class DataWorker
    {
        #region МЕТОДЫ, ВОЗВРАЩАЮЩИЕ ЗНАЧЕНИЯe

        /// <summary>
        /// Получить все департаменты
        /// </summary>
        /// <returns></returns>
        public static List<Department> GetAllDepartments()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Departments.ToList();
                return result;
            }
        }

        /// <summary>
        /// Получить все позиции
        /// </summary>
        /// <returns></returns>
        public static List<Position> GetAllPositions()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Positions.ToList();
                return result;
            }
        }

        /// <summary>
        /// Получить всех сотрудников
        /// </summary>
        /// <returns></returns>
        public static List<User> GetAllUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Users.ToList();
                return result;
            }
        }

        /// <summary>
        /// Получить всех клиентов
        /// </summary>
        /// <returns></returns>
        public static List<Client> GetAllClients()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Clients.ToList();
                return result;
            }
        }

        /// <summary>
        /// Получить все депозиты
        /// </summary>
        /// <returns></returns>
        public static List<Deposit> GetAllDeposits()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Deposits.ToList();
                return result;
            }
        }
        #endregion

        #region МЕТОДЫ СОЗДАНИЯ

        /// <summary>
        /// Создать Департамент
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CreateDepartment(string name)
        {
            string result = "Уже существует";
            using(ApplicationContext db = new ApplicationContext())
            {
                //проверяем, суще ли отдел
                bool checkIsExist = db.Departments.Any(el => el.Name == name);
                if(!checkIsExist)
                {
                    Department newDepartment = new Department { Name = name };
                    db.Departments.Add(newDepartment);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        /// <summary>
        /// Создать позицию
        /// </summary>
        /// <param name="name"></param>
        /// <param name="salary"></param>
        /// <param name="maxnumber"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        public static string CreatePosition(string name,decimal salary, int maxnumber,Department department)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем, суще ли позиция
                bool checkIsExist = db.Positions.Any(el => el.Name == name && el.Salary == salary);
                if (!checkIsExist)
                {
                    Position newPosition = new Position
                    {
                        Name = name,
                        Salary = salary,
                        MaxNumber = maxnumber,
                        DepartmentId = department.Id
                    };
                    db.Positions.Add(newPosition);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        /// <summary>
        /// создать сотрудника
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surName"></param>
        /// <param name="phone"></param>
        /// <param name="position"></param>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        public static string CreateUser(string name,string surName, string phone, Position position, DateTime dateOfBirth)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем, суще ли сотрудник
                bool checkIsExist = db.Users.Any(el => el.Name == name && el.SurName == surName && el.Position == position);
                if (!checkIsExist)
                {
                    User newUser = new User
                    {
                        Name = name,
                        SurName = surName,
                        Phone = phone,
                        PositionId = position.Id,
                        DateOfBirth = dateOfBirth
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        /// <summary>
        /// Создать Клиента
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surName"></param>
        /// <param name="phone"></param>
        /// <param name="isVip"></param>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        public static string CreateClient(string name, string surName, string phone, bool isVip, DateTime dateOfBirth)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем, суще ли клиент
                bool checkIsExist = db.Clients.Any(el => el.Name == name && el.SurName == surName);
                if (!checkIsExist)
                {
                    Client newClient = new Client
                    {
                        Name = name,
                        SurName = surName,
                        Phone = phone,
                        IsVIP = isVip,
                        DateOfBirth = dateOfBirth
                    };
                    db.Clients.Add(newClient);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        /// <summary>
        /// Создать депозит
        /// </summary>
        /// <param name="client"></param>
        /// <param name="depositPercent"></param>
        /// <param name="startSum"></param>
        /// <param name="isCapitalized"></param>
        /// <param name="dateOfStart"></param>
        /// <param name="monthsCount"></param>
        /// <param name="responsibleEmployee"></param>
        /// <returns></returns>
        public static string CreateDeposit(Client client, double depositPercent, int startSum, bool isCapitalized,
            DateTime dateOfStart, int monthsCount, User responsibleEmployee)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //  НЕ проверяем, суще ли Депозит
                Deposit newDeposit = new Deposit
                {
                    Client  = client,
                    DepositPercent  = depositPercent,
                    StartSum = startSum,
                    IsCapitalized = isCapitalized,
                    DateOfStart = dateOfStart,
                    MonthsCount = monthsCount,
                    ResponsibleEmployee = responsibleEmployee
                };
                db.Deposits.Add(newDeposit);
                db.SaveChanges();
                result = "Сделано!";
                return result;
            }
        }

        #endregion

        #region МЕТОДЫ УДАЛЕНИЯ
        /// <summary>
        /// удалить отдел
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public static string DeleteDepartment(Department department)
        {
            string result = "Такого отдела не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Departments.Remove(department);
                db.SaveChanges();
                result = "Сделано! Отдел " + department.Name + "удален";
            }
            return result;
        }

        /// <summary>
        /// удалить позицию
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static string DeletePosition(Position position)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Positions.Remove(position);
                db.SaveChanges();
                result = "Сделано! Отдел " + position.Name + "удален";
            }
            return result;
        }

        /// <summary>
        /// удалить сотрудника
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string DeleteUser(User user)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
                result = "Сделано! Сотрудник " + user.Name + "удален";
            }
            return result;
        }

        /// <summary>
        /// удалить Клиента
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static string DeleteClient(Client client)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Clients.Remove(client);
                db.SaveChanges();
                result = "Сделано! Клиент " + client.Name + "удален";
            }
            return result;
        }

        /// <summary>
        /// удалить Депозит
        /// </summary>
        /// <param name="deposit"></param>
        /// <returns></returns>
        public static string DeleteDeposit(Deposit deposit)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Deposits.Remove(deposit);
                db.SaveChanges();
                result = "Сделано! Депозит " + deposit.Id + "удален";
            }
            return result;
        }
        #endregion

        #region МЕТОДЫ РЕДАКТИРОВАНИЯ
        /// <summary>
        /// Редактировать отдел
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public static string EditDepartment(Department oldDepartment, string newName)
        {
            string result = "Такого отдела не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Department department = db.Departments.FirstOrDefault(d => d.Id == oldDepartment.Id);
                department.Name = newName;
                db.SaveChanges();
                result = "Сделано! Отдел " + department.Name + "изменен";
            }
            return result;
        }

        /// <summary>
        /// редактировать позицию
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static string EditPosition(Position oldPosition,string newName,int newMaxNumber, decimal newSalary, Department newDepartment)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Position position = db.Positions.FirstOrDefault(p => p.Id == oldPosition.Id);
                position.Name = newName;
                position.Salary = newSalary;
                position.MaxNumber = newMaxNumber;
                position.Department = newDepartment;
                db.SaveChanges();
                result = "Сделано! Позиция " + position.Name + "Изменена";
            }
            return result;
        }

        /// <summary>
        /// редактировать сотрудника
        /// </summary>
        /// <param name="oldUser"></param>
        /// <param name="newName"></param>
        /// <param name="newSurName"></param>
        /// <param name="newPhone"></param>
        /// <param name="newPosition"></param>
        /// <param name="newDateOfBirth"></param>
        /// <returns></returns>
        public static string EditUser(User oldUser, string newName, string newSurName, string newPhone, Position newPosition, DateTime newDateOfBirth)
        {
            string result = "Такого сотрудника не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.FirstOrDefault(p => p.Id == oldUser.Id);
                if (user != null)
                {
                    user.Name = newName;
                    user.SurName = newSurName;
                    user.Phone = newPhone;
                    user.Position = newPosition;
                    user.DateOfBirth = newDateOfBirth;
                    db.SaveChanges();
                    result = "Сделано! Сотрудник " + user.Name + "Изменен";
                }
            }
            return result;
        }

        /// <summary>
        /// Редактировать клиента
        /// </summary>
        /// <param name="oldClient"></param>
        /// <param name="newName"></param>
        /// <param name="newSurName"></param>
        /// <param name="newPhone"></param>
        /// <param name="newIsVip"></param>
        /// <param name="newDateOfBirth"></param>
        /// <returns></returns>
        public static string EditClient(Client oldClient, string newName, string newSurName, string newPhone, bool newIsVip, DateTime newDateOfBirth)
        {
            string result = "Такого клиента не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Client client = db.Clients.FirstOrDefault(p => p.Id == oldClient.Id);
                if (client != null)
                {
                    client.Name = newName;
                    client.SurName = newSurName;
                    client.Phone = newPhone;
                    client.IsVIP = newIsVip;
                    client.DateOfBirth = newDateOfBirth;
                    db.SaveChanges();
                    result = "Сделано! Клиент " + client.Name + "Изменен";
                }
            }
            return result;
        }

        /// <summary>
        /// Редактировать депозит
        /// </summary>
        /// <param name="oldDeposit"></param>
        /// <param name="newClient"></param>
        /// <param name="newDepositPercent"></param>
        /// <param name="newStartSum"></param>
        /// <param name="newIsCapitalized"></param>
        /// <param name="newDateOfStart"></param>
        /// <param name="newMonthsCount"></param>
        /// <param name="newResponsibleEmployee"></param>
        /// <returns></returns>
        public static string EditDeposit(Deposit oldDeposit, Client newClient, double newDepositPercent, int newStartSum, bool newIsCapitalized,
            DateTime newDateOfStart, int newMonthsCount, User newResponsibleEmployee)
        {
            string result = "Такого Депозита не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Deposit deposit = db.Deposits.FirstOrDefault(p => p.Id == oldDeposit.Id);
                if (deposit != null)
                {
                    deposit.Client = newClient;
                    deposit.DepositPercent = newDepositPercent;
                    deposit.StartSum = newStartSum;
                    deposit.IsCapitalized = newIsCapitalized;
                    deposit.DateOfStart = newDateOfStart;
                    deposit.MonthsCount = newMonthsCount;
                    deposit.ResponsibleEmployee  = newResponsibleEmployee;
                    db.SaveChanges();
                    result = "Сделано! Депозит " + deposit.Id + "Изменен";
                }
            }
            return result;
        }
        #endregion
    }
}
