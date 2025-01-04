using System;
using System.Drawing;
using System.Windows.Forms;
using AdminSERMAC.Services;

namespace AdminSERMAC.Forms
{
    public class VentasForm : Form
    {
        private Label numeroGuiaLabel;
        private TextBox numeroGuiaTextBox;
        private Label rutLabel;
        private ComboBox rutComboBox;
        private Label clienteLabel;
        private TextBox clienteTextBox;
        private Label direccionLabel;
        private TextBox direccionTextBox;
        private Label giroLabel;
        private TextBox giroTextBox;
        private Label fechaEmisionLabel;
        private DateTimePicker fechaEmisionPicker;
        private Label totalVentaLabel;
        private TextBox totalVentaTextBox;

        private DataGridView ventasDataGridView;
        private Button finalizarButton;
        private CheckBox pagarConCreditoCheckBox;

        private SQLiteService sqliteService;
        private double totalVenta = 0;

        public VentasForm()
        {
            this.Text = "Gestión de Ventas";
            this.Width = 1000;
            this.Height = 800;

            sqliteService = new SQLiteService();

            InitializeComponents(); // Inicializar todos los controles
            ConfigureEvents();      // Asignar eventos a los controles
        }

        private void InitializeComponents()
        {
            // Etiqueta y cuadro de texto para número de guía
            numeroGuiaLabel = new Label { Text = "Número de Guía:", Location = new Point(20, 20), Width = 120 };
            numeroGuiaTextBox = new TextBox { Location = new Point(150, 20), Width = 150 };

            // Etiqueta y combo box para RUT
            rutLabel = new Label { Text = "RUT:", Location = new Point(20, 60), Width = 120 };
            rutComboBox = new ComboBox { Location = new Point(150, 60), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            // Etiqueta y cuadro de texto para cliente
            clienteLabel = new Label { Text = "Cliente:", Location = new Point(20, 100), Width = 120 };
            clienteTextBox = new TextBox { Location = new Point(150, 100), Width = 200, ReadOnly = true };

            // Etiqueta y cuadro de texto para dirección
            direccionLabel = new Label { Text = "Dirección:", Location = new Point(20, 140), Width = 120 };
            direccionTextBox = new TextBox { Location = new Point(150, 140), Width = 200, ReadOnly = true };

            // Etiqueta y cuadro de texto para giro
            giroLabel = new Label { Text = "Giro:", Location = new Point(20, 180), Width = 120 };
            giroTextBox = new TextBox { Location = new Point(150, 180), Width = 200, ReadOnly = true };

            // Etiqueta y selector de fecha de emisión
            fechaEmisionLabel = new Label { Text = "Fecha de Emisión:", Location = new Point(400, 20), Width = 120 };
            fechaEmisionPicker = new DateTimePicker { Location = new Point(540, 20), Width = 200 };

            // DataGridView para ventas
            ventasDataGridView = new DataGridView
            {
                Location = new Point(20, 220),
                Size = new Size(940, 350),
                AllowUserToAddRows = true,
                AllowUserToDeleteRows = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            ventasDataGridView.Columns.Add("Codigo", "Código");
            ventasDataGridView.Columns.Add("Descripcion", "Descripción");
            ventasDataGridView.Columns.Add("CantidadExistente", "Cantidad Existente");
            ventasDataGridView.Columns.Add("Bandejas", "Bandejas");
            ventasDataGridView.Columns.Add("KilosBruto", "Kilos Bruto");
            ventasDataGridView.Columns.Add("KilosNeto", "Kilos Neto");
            ventasDataGridView.Columns.Add("Precio", "Precio");
            ventasDataGridView.Columns.Add("Total", "Total");

            // Botón para finalizar venta
            finalizarButton = new Button
            {
                Text = "Finalizar Venta",
                Location = new Point(800, 600),
                Width = 150,
                Height = 40,
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White
            };

            // CheckBox para pago con crédito
            pagarConCreditoCheckBox = new CheckBox
            {
                Text = "Pago con crédito",
                Location = new Point(600, 600),
                Width = 150
            };

            // Etiqueta y cuadro de texto para total de la venta
            totalVentaLabel = new Label { Text = "Total Venta:", Location = new Point(400, 600), Width = 100 };
            totalVentaTextBox = new TextBox { Location = new Point(500, 600), Width = 150, ReadOnly = true };

            // Agregar controles al formulario
            this.Controls.AddRange(new Control[]
            {
                numeroGuiaLabel, numeroGuiaTextBox,
                rutLabel, rutComboBox,
                clienteLabel, clienteTextBox,
                direccionLabel, direccionTextBox,
                giroLabel, giroTextBox,
                fechaEmisionLabel, fechaEmisionPicker,
                ventasDataGridView,
                finalizarButton, pagarConCreditoCheckBox,
                totalVentaLabel, totalVentaTextBox
            });
        }

        private void ConfigureEvents()
        {
            // Asegurar que los controles no sean nulos antes de asignar eventos
            if (finalizarButton != null)
                finalizarButton.Click += FinalizarButton_Click;

            if (ventasDataGridView != null)
                ventasDataGridView.CellEndEdit += VentasDataGridView_CellEndEdit;

            if (rutComboBox != null)
                rutComboBox.SelectedIndexChanged += RutComboBox_SelectedIndexChanged;
        }

        private void VentasDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Manejo de cambios en las celdas del DataGridView
        }

        private void RutComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Manejo de selección de cliente
        }

        private void FinalizarButton_Click(object sender, EventArgs e)
        {
            // Lógica para finalizar la venta
        }
    }
}
