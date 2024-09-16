using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace keyboardGameTrainer
{
    public partial class rules : UserControl
    {
        public rules()
        {
            InitializeComponent();
        }

        private void rules_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "Left Hand\r\n\r\nFifth (pinkie) finger: a, z, q, and 1, along with the left shift key and the tab/caps lock key.\r\n\r\nFourth (ring) finger: s, x, w, and 2.\r\n\r\nThird (middle) finger: d, c, e, and 3.\r\n\r\nSecond (index) finger: f, v, b, r, t, 4, 5, and 6.\r\n\r\nThumb: space bar\r\n\r\nRight Hand\r\n\r\nFifth finger: ; (semi-colon), /, p, 0 (zero), along with all symbols to the right of the 0 and p keys and the right shift key.\r\n\r\nFourth finger: l, . (period), o, and 9.\r\n\r\nThird finger: k, , (comma), i, and 8.\r\n\r\nSecond finger: j, n, m, u, and 7.\r\n\r\nThumb: space bar";
            richTextBox1.ReadOnly = true;
        }
    }
}
