using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Zhuangbility
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            try { 
                FileStream fs = new FileStream("food.txt", FileMode.Open, FileAccess.Read);
                StreamReader m_streamReader = new StreamReader(fs);
                m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                String strLine;
                while ((strLine = m_streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(strLine);
                    foods.Add(strLine);
                }
                m_streamReader.Close();
            } catch (Exception exception) {
                Console.WriteLine(exception);
                foods.Add("盖浇饭");
                foods.Add("砂锅");
                foods.Add("大排档");
                foods.Add("米线");
                foods.Add("满汉全席");
                foods.Add("西餐");
                foods.Add("麻辣烫");
                foods.Add("自助餐");
                foods.Add("炒面");
                foods.Add("快餐");
                foods.Add("水果");
                foods.Add("西北风");
                foods.Add("馄饨");
                foods.Add("火锅");
                foods.Add("烧烤");
                foods.Add("泡面");
                foods.Add("速冻");
                foods.Add("水饺");
                foods.Add("日本料理");
                foods.Add("涮羊肉");
                foods.Add("味千拉面");
                foods.Add("肯德基");
                foods.Add("面包");
                foods.Add("扬州炒饭");
                foods.Add("自助餐");
                foods.Add("茶餐厅");
                foods.Add("海底捞");
                foods.Add("咖啡");
                foods.Add("比萨");
                foods.Add("麦当劳");
                foods.Add("兰州拉面");
                foods.Add("沙县小吃");
                foods.Add("烤鱼");
                foods.Add("海鲜");
                foods.Add("铁板烧");
                foods.Add("韩国料理");
                foods.Add("粥");
                foods.Add("快餐");
                foods.Add("东南亚菜");
                foods.Add("甜点");
                foods.Add("农家菜");
                foods.Add("川菜");
                foods.Add("粤菜");
                foods.Add("湘菜");
                foods.Add("徽菜");
                foods.Add("本帮菜");
                foods.Add("竹笋烤肉");
                foods.Add("美团外卖");
                foods.Add("饿了么");
                foods.Add("水果");

            }
        }

        public static string word = "加载中...";
        public static List<String> foods = new List<string>();
        public static int index = 0;
        public static int click = 0;



        private DispatcherTimer timer;




        public void btnMore_Click(object sender, RoutedEventArgs e)
        {
            if(click % 2 == 0) {
                this.btnMore.Content = "🆗 就是你";
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(15);
                timer.Tick += timer1_Tick;
                timer.Start();
            }else
            {
                this.btnMore.Content = "⏭ 开始决策";
                timer.Stop();
                this.food.Text = "美团外卖";
            }
            click ++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int size = foods.Count() -1;
            int count = index > size ? index - size : index;
            index = count;
            this.food.Text = foods[count];
            index++; 
        }

        public void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetDataObject(this.content.Text+this.food.Text);
            MessageBox.Show("复制成功!", "已经复制到粘贴版" , MessageBoxButton.OK, MessageBoxImage.Exclamation);
            SaveWindow(this, 96, "food.png");

        }

        public static void SaveWindow(Window window, int dpi, string filename)
        {

            var rtb = new RenderTargetBitmap(
                (int)window.Width, //width
                (int)window.Height, //height
                dpi, //dpi x
                dpi, //dpi y
                PixelFormats.Pbgra32 // pixelformat
                );
            rtb.Render(window);

            SaveRTBAsPNG(rtb, filename);

        }

        private static void SaveRTBAsPNG(RenderTargetBitmap bmp, string filename)
        {
            var enc = new System.Windows.Media.Imaging.PngBitmapEncoder();
            enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bmp));

            using (var stm = System.IO.File.Create(filename))
            {
                enc.Save(stm);
            }
        }
    }
}
