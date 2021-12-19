﻿using TheBank2.Model;
using TheBank2.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TheBank2.ViewModel
{
    class DataManageVM : INotifyPropertyChanged
    {
        #region СВОЙСТВА
        //все отделы
        private List<Department> allDepartments = DataWorker.GetAllDepartments();
        public List<Department> AllDepartments
        {
            get { return allDepartments; }
            set
            {
                allDepartments = value;
                NotifyPropertyChanged("AllDepartments");
            }
        }

        //все позиции
        private List<Position> allPositions = DataWorker.GetAllPositions();
        public List<Position> AllPositions
        {
            get { return allPositions; }
            set
            {
                allPositions = value;
                NotifyPropertyChanged("AllPositions");
            }
        }

        //все юзеры
        private List<User> allUsers = DataWorker.GetAllUsers();
        public List<User> AllUsers
        {
            get { return allUsers; }
            set
            {
                allUsers = value;
                NotifyPropertyChanged("AllUsers");
            }
        }

        //все клиенты
        private List<Client> allClients = DataWorker.GetAllClients();
        public List<Client> AllClients
        {
            get { return allClients; }
            set
            {
                allClients = value;
                NotifyPropertyChanged("Client");
            }
        }

        //все депозиты
        private List<Deposit> allDeposits = DataWorker.GetAllDeposits();
        public List<Deposit> AllDeposits
        {
            get { return allDeposits; }
            set
            {
                allDeposits = value;
                NotifyPropertyChanged("AllDeposits");
            }
        }

        /// <summary>
        /// Cобытие "свойство изменилось"
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Обработчик события "свойство изменилось"
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region МЕТОДЫ ОТКРЫТИЯ ОКОН ДЛЯ ДОБАВЛЕНИЯ

        private void OpenAddDepartmentWindowMethod()
        {
            AddNewDepartmentWindow newDepartmentWindow = new();
            SetCenterPositionAndOpen(newDepartmentWindow);
        }

        private void OpenAddPositionWindowMethod()
        {
            AddNewPositionWindow newPositionWindow = new();
            SetCenterPositionAndOpen(newPositionWindow);
        }

        private void OpenAddUserWindowMethod()
        {
            AddNewUserWindow newUserWindow = new();
            SetCenterPositionAndOpen(newUserWindow);
        }

        private void OpenAddClientWindowMethod()
        {
            AddNewClientWindow newClientWindow = new();
            SetCenterPositionAndOpen(newClientWindow);
        }

        private void OpenAddDepositWindowMethod()
        {
            AddNewDepositWindow newDepositWindow = new();
            SetCenterPositionAndOpen(newDepositWindow);
        }

        /// <summary>
        /// Открывает окно в центре предыдущего окна
        /// </summary>
        /// <param name="window"></param>
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion

        #region МЕТОДЫ ОТКРЫТИЯ ОКОН ДЛЯ РЕДАКТИРОВАНИЯ

        private void OpenEditDepartmentWindowMethod()
        {
            EditDepartmentWindow editDepartmentWindow = new();
            SetCenterPositionAndOpen(editDepartmentWindow);
        }

        private void OpenEditPositionWindowMethod()
        {
            EditPositionWindow editPositionWindow = new();
            SetCenterPositionAndOpen(editPositionWindow);
        }

        private void OpenEditUserWindowMethod()
        {
            EditUserWindow editUserWindow = new();
            SetCenterPositionAndOpen(editUserWindow);
        }

        private void OpenEditClientWindowMethod()
        {
            EditClientWindow editClientWindow = new();
            SetCenterPositionAndOpen(editClientWindow);
        }

        private void OpenEditDepositWindowMethod()
        {
            EditDepositWindow editDepositWindow = new();
            SetCenterPositionAndOpen(editDepositWindow);
        }
        #endregion

        #region КОМАНДЫ ОТКРЫТИЯ ОКОН СОЗДАНИЯ

        /// <summary>
        /// Команда открытия окна для создания нового департмента
        /// </summary>
        private RelayCommand openAddNewDepartmentWnd;
        public RelayCommand OpenAddNewDepartmentWnd
        {
            get
            {
                return openAddNewDepartmentWnd ?? new RelayCommand( obj =>
                {
                    OpenAddDepartmentWindowMethod();
                }
                    );
            }
        }

        /// <summary>
        /// Команда открытия окна для создания новой позиции
        /// </summary>
        private RelayCommand openAddNewPositionWnd;
        public RelayCommand OpenAddNewPositionWnd
        {
            get
            {
                return openAddNewPositionWnd ?? new RelayCommand(obj =>
                {
                    OpenAddPositionWindowMethod();
                }
                    );
            }
        }

        /// <summary>
        /// Команда открытия окна для создания нового юзера
        /// </summary>
        private RelayCommand openAddNewUserWnd;
        public RelayCommand OpenAddNewUserWnd
        {
            get
            {
                return openAddNewUserWnd ?? new RelayCommand(obj =>
                {
                    OpenAddUserWindowMethod();
                }
                    );
            }
        }

        /// <summary>
        /// Команда открытия окна для создания нового клиента
        /// </summary>
        private RelayCommand openAddNewClientWnd;
        public RelayCommand OpenAddNewClientWnd
        {
            get
            {
                return openAddNewClientWnd ?? new RelayCommand(obj =>
                {
                    OpenAddClientWindowMethod();
                }
                    );
            }
        }

        /// <summary>
        /// Команда открытия окна для создания нового депозита
        /// </summary>
        private RelayCommand openAddNewDepositWnd;
        public RelayCommand OpenAddNewDepositWnd
        {
            get
            {
                return openAddNewDepositWnd ?? new RelayCommand(obj =>
                {
                    OpenAddDepositWindowMethod();
                }
                    );
            }
        }

        #endregion
    }
}
