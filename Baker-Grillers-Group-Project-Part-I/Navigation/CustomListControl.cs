using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using UserAuthentication;

namespace Baker_Grillers_Group_Project_Part_I.Controls
{
    /// <summary>
    /// EnhancedListView control that improves upon DataGridView with clickable items
    /// </summary>
    public partial class CustomListControl : System.Windows.Forms.UserControl
    {
        // Event to handle when an item is selected
        public event EventHandler<ItemSelectedEventArgs> ItemSelected;
        string selectedSport;

        public CustomListControl()
        {
            InitializeComponent();
            SetupEvents();
        }

        private void SetupEvents()
        {

            // Double click
            this.gridView.CellDoubleClick += GridView_CellDoubleClick;

            // Change cursor when hovering over rows to indicate they're clickable
            this.gridView.CellMouseEnter += GridView_CellMouseEnter;
            this.gridView.CellMouseLeave += GridView_CellMouseLeave;

            // Visual feedback on row selection
            this.gridView.SelectionChanged += GridView_SelectionChanged;

            // Hack to remove a persistent blue color on the grid
            this.gridView.ClearSelection();
            gridView.EnableHeadersVisualStyles = false;
            Color headerColor = Color.FromArgb(221, 255, 230);
            gridView.ColumnHeadersDefaultCellStyle.BackColor = headerColor; // Light gray
            gridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerColor;
            gridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        // Custom row styling on selection
        private void GridView_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.gridView.Rows)
            {
                if (row.Selected)
                {
                    //row.DefaultCellStyle.BackColor = Color.FromArgb(221, 255, 230);
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 255, 214);
                    row.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void GridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.Cursor = Cursors.Hand;
            }
        }

        private void GridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void GridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the ID column (first column should be the ID)
                var idColumn = this.gridView.Columns.Contains("TeamID") ? "TeamID" :
                               this.gridView.Columns.Contains("PlayerID") ? "PlayerID" :
                               this.gridView.Columns[0].Name;

                // Get the name column (usually second column)
                var nameColumn = this.gridView.Columns.Contains("TeamName") ? "TeamName" :
                                 this.gridView.Columns.Contains("PlayerName") ? "PlayerName" :
                                 this.gridView.Columns[1].Name;

                int id = Convert.ToInt32(this.gridView.Rows[e.RowIndex].Cells[idColumn].Value);
                string name = this.gridView.Rows[e.RowIndex].Cells[nameColumn].Value.ToString();

                // Raise the event with the selected item's ID and name
                ItemSelected?.Invoke(this, new ItemSelectedEventArgs(id, name));
            }
        }


        // Set data source for the gridView
        public void SetData(DataTable data, string selectedSport)
        {
            this.gridView.DataSource = data;
            this.selectedSport = selectedSport;

            // Update appearance
            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            if (this.gridView.Columns.Count > 0)
            {
                // Hide unnecessary columns
                if (this.gridView.Columns.Contains("TeamID")) // Team view
                {
                    this.gridView.Columns["TeamID"].Visible = false;
                    this.gridView.Columns["TeamName"].HeaderText = "Team";
                    switch(selectedSport)
                    {
                        case "csgo":
                            gridView.Columns["TotalMaps"].HeaderText = "Maps Played";
                            gridView.Columns["KdDiff"].HeaderText = "K/D Diff";
                            gridView.Columns["Kd"].HeaderText = "K/D Ratio";
                            gridView.Columns["Rating"].HeaderText = "Rating";
                            break;
                        case "nfl":
                            gridView.Columns["WinPercentage"].HeaderText = "Win %";
                            gridView.Columns["TotalTD"].HeaderText = "Total TDs";
                            gridView.Columns["WinPercentage"].DefaultCellStyle.Format = "P2";
                            break;
                        case "nba":
                            gridView.Columns["TeamAbbr"].HeaderText = "Abbr.";
                            gridView.Columns["TotalPoints"].HeaderText = "Points";
                            gridView.Columns["FGPercentage"].HeaderText = "Field Goal %";
                            gridView.Columns["ThreePtPercentage"].HeaderText = "3 Point %";
                            gridView.Columns["TotalRebounds"].HeaderText = "Rebounds";
                            gridView.Columns["FGPercentage"].DefaultCellStyle.Format = "F1";
                            gridView.Columns["ThreePtPercentage"].DefaultCellStyle.Format = "F1";
                            break;
                    }
                }
                if (gridView.Columns.Contains("PlayerID")) // Player view
                {
                    gridView.Columns["PlayerID"].Visible = false;
                    gridView.Columns["PlayerName"].HeaderText = "Player";
                    gridView.Columns["TeamName"].HeaderText = "Team";
                    switch (selectedSport)
                    {
                        case "csgo":

                            gridView.Columns["KdDiff"].HeaderText = "K/D Diff";
                            gridView.Columns["Kd"].HeaderText = "K/D Ratio";
                            gridView.Columns["Rating"].HeaderText = "Rating";
                            gridView.Columns["TotalMaps"].HeaderText = "Maps Played";
                            gridView.Columns["TotalRounds"].HeaderText = "Rounds Played";
                            break;
                        case "nfl":
                            gridView.Columns["PassingYards"].HeaderText = "Passing Yards";
                            gridView.Columns["TdPasses"].HeaderText = "Touchdown Passes";
                            gridView.Columns["RushYards"].HeaderText = "Rush Yards";
                            gridView.Columns["RushTds"].HeaderText = "Rush Touchdowns";
                            gridView.Columns["ReceivingYards"].HeaderText = "Receiving Yards";
                            gridView.Columns["ReceivingTds"].HeaderText = "Receiving Touchdowns";
                            break;
                        case "nba":
                            gridView.Columns["TotalPoints"].HeaderText = "Points";
                            gridView.Columns["TotalRebounds"].HeaderText = "Rebounds";
                            gridView.Columns["FieldGoalPercentage"].HeaderText = "Field Goal %";
                            gridView.Columns["ThreePointPercentage"].HeaderText = "3 Point %";
                            gridView.Columns["FieldGoalPercentage"].DefaultCellStyle.Format = "F1";
                            gridView.Columns["ThreePointPercentage"].DefaultCellStyle.Format = "F1";
                            break;
                    }
                }


                // Customize grid
                gridView.RowTemplate.Height = 30;
                //gridView.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10F);
                gridView.DefaultCellStyle.Padding = new Padding(5);
                //gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                //gridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

                // Enable alternatign colors
                gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
            }
        }

        private void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    /// <summary>
    /// Event arguments for item selection
    /// </summary>
    public class ItemSelectedEventArgs : EventArgs
    {
        public int ItemId { get; private set; }
        public string ItemName { get; private set; }

        public ItemSelectedEventArgs(int id, string name)
        {
            ItemId = id;
            ItemName = name;
        }
    }

}