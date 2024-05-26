﻿using System.Data;
using System.Windows;
-11,14 + 13,56 @@

namespace WpfApp_3._05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DBManager dbManager;

        public MainWindow()
        {
            InitializeComponent();
            string connectionString = "Your_Connection_String_Here";
            dbManager = new DBManager(connectionString);
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void ExecuteCustomQuery_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = SqlQueryTextBox.Text;
                DataTable result = dbManager.ExecuteQuery(query);
                ResultsListBox.ItemsSource = result.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing query: " + ex.Message);
            }
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO Products (ProductName, ProductType, SupplierID, Quantity, CostPrice, DeliveryDate) " +
                           "VALUES ('New Product Name', 'New Product Type', 1, 0, 0, GETDATE())";
            dbManager.ExecuteNonQuery(query);
            MessageBox.Show("New product added successfully.");
        }

        private void AddProductType_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO ProductTypes (ProductTypeName) VALUES ('New Product Type')";
            dbManager.ExecuteNonQuery(query);
            MessageBox.Show("New product type added successfully.");
        }

        private void AddSupplier_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO Suppliers (SupplierName, SupplierLocation) VALUES ('New Supplier Name', 'New Supplier Location')";
            dbManager.ExecuteNonQuery(query);
            MessageBox.Show("New supplier added successfully.");
        }
    }
}