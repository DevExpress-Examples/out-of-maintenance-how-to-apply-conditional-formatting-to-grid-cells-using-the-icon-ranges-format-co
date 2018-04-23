using DevExpress.DashboardCommon;

namespace Grid_IconRangeCondition {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        public Form1() {
            InitializeComponent();
            Dashboard dashboard = new Dashboard(); dashboard.LoadFromXml(@"..\..\Data\Dashboard.xml");
            dashboardViewer1.Dashboard = dashboard;
            GridDashboardItem grid = (GridDashboardItem)dashboard.Items["gridDashboardItem1"];
            GridMeasureColumn extendedPrice = (GridMeasureColumn)grid.Columns[1];

            GridItemFormatRule rangeRule = new GridItemFormatRule(extendedPrice);
            FormatConditionRangeSet rangeCondition = 
                new FormatConditionRangeSet(FormatConditionRangeSetPredefinedType.PositiveNegative3);
            rangeRule.Condition = rangeCondition;

            grid.FormatRules.AddRange(rangeRule);
        }

        private void button1_Click(object sender, System.EventArgs e) {
            GridDashboardItem grid = 
                (GridDashboardItem)dashboardViewer1.Dashboard.Items["gridDashboardItem1"];
            GridItemFormatRule rangeRule = grid.FormatRules[0];
            FormatConditionRangeSet rangeCondition = (FormatConditionRangeSet)rangeRule.Condition;
            RangeInfo range3 = rangeCondition.RangeSet[2];
            range3.Value = 50;
            range3.StyleSettings = 
                new IconSettings(FormatConditionIconType.DirectionalYellowUpInclineArrow);

            RangeInfo range4 = new RangeInfo();
            range4.Value = 75;
            range4.StyleSettings = 
                new IconSettings(FormatConditionIconType.IndicatorCircledGreenCheck);
            rangeCondition.RangeSet.Add(range4);

            rangeRule.Condition = rangeCondition;
        }
    }
}
