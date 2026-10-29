using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckForUpdatesAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }





        private const string CurrentVersion = "1.0.0";

        private const string GitHubOwner = "OWNER";
        private const string GitHubRepo = "REPO";

        private static readonly HttpClient httpClient = new HttpClient();

        private async void btnCheckForUpdates_Click(object sender, EventArgs e)
        {
            btnCheckForUpdates.Enabled = false;

            progressBarUpdate.Style = ProgressBarStyle.Marquee;
            progressBarUpdate.MarqueeAnimationSpeed = 30;

            lblVersion.Text = $"Version: {CurrentVersion}";
            lblUpdateStatus.Text = "جاري تفقد التحديث...";

            try
            {
                string apiUrl =
                    $"https://api.github.com/repos/{GitHubOwner}/{GitHubRepo}/releases/latest";

                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("MyUpdateChecker/1.0");

                using HttpResponseMessage response =
                    await httpClient.GetAsync(apiUrl);

                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                using JsonDocument document = JsonDocument.Parse(json);

                JsonElement release = document.RootElement;

                string latestVersion = release
                    .GetProperty("tag_name")
                    .GetString() ?? "";

                string releaseUrl = release
                    .GetProperty("html_url")
                    .GetString() ?? "";

                latestVersion = latestVersion.Trim().TrimStart('v', 'V');

                if (!Version.TryParse(latestVersion, out Version? latest))
                {
                    lblUpdateStatus.Text = "تعذر قراءة رقم الإصدار.";
                    return;
                }

                if (!Version.TryParse(CurrentVersion, out Version? current))
                {
                    lblUpdateStatus.Text = "رقم الإصدار الحالي غير صحيح.";
                    return;
                }

                if (latest > current)
                {
                    lblUpdateStatus.Text =
                        $"يتوفر تحديث جديد: {latest}";

                    MessageBox.Show(
                        $"يتوفر إصدار جديد: {latest}\n" +
                        $"إصدارك الحالي: {current}\n\n" +
                        $"صفحة التحديث:\n{releaseUrl}",
                        "تحديث جديد",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    lblUpdateStatus.Text = "البرنامج محدّث إلى آخر إصدار.";

                    MessageBox.Show(
                        "أنت تستخدم أحدث إصدار من البرنامج.",
                        "لا توجد تحديثات",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (HttpRequestException)
            {
                lblUpdateStatus.Text = "تعذر الاتصال بخادم التحديثات.";

                MessageBox.Show(
                    "تعذر الاتصال بـ GitHub.\nتحقق من اتصال الإنترنت ومن إعدادات المستودع.",
                    "خطأ في الاتصال",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (JsonException)
            {
                lblUpdateStatus.Text = "تعذر قراءة معلومات التحديث.";

                MessageBox.Show(
                    "تعذر قراءة بيانات الإصدار المنشور.",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                lblUpdateStatus.Text = "حدث خطأ أثناء تفقد التحديثات.";

                MessageBox.Show(
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                progressBarUpdate.MarqueeAnimationSpeed = 0;
                progressBarUpdate.Style = ProgressBarStyle.Blocks;
                progressBarUpdate.Value = 0;

                btnCheckForUpdates.Enabled = true;
            }
        }











    }
}
