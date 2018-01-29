using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqDemo
{
    public class SetDataGridView
    {
        DataGridView _dgv;
        public SetDataGridView(DataGridView dgv)
        {
            _dgv = dgv;
            NonLastRow();
            ColumnAutoFit();
        }
        void NonLastRow()
        {
            _dgv.AllowUserToAddRows = false;
        }

        void ColumnAutoFit()
        {
            int width = 0;
            //使列自使用宽度
            //对于DataGridView的每一个列都调整
            for (int i = 0; i < _dgv.Columns.Count; i++)
            {
                //将每一列都调整为自动适应模式
                _dgv.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                //记录整个DataGridView的宽度
                width += _dgv.Columns[i].Width;
            }
            //判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，
            //则将DataGridView的列自动调整模式设置为显示的列即可，
            //如果是小于原来设定的宽度，将模式改为填充。
            if (width > _dgv.Size.Width)
            {
                _dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                _dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            //冻结某列 从左开始 0，1，2
            _dgv.Columns[1].Frozen = true;

        }


    }
}
