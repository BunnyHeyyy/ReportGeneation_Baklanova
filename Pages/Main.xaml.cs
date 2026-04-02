using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Org.BouncyCastle.Bcpg;
using ReportGeneration_Baklanova.Classes;

namespace ReportGeneration_Baklanova.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public List<GroupContext> AllGroups = GroupContext.AllGroups();
        public List<StudentContext> AllStudents = StudentContext.AllStudents();
        public List<WorkContext> AllWorks = WorkContext.AllWorks();
        public List<EvaluationContext> AllEvalutions = EvaluationContext.AllEvaluations();
        public List<DisciplineContext> AllDisciplines = DisciplineContext.AllDisciplines();
        public Main()
        {
            InitializeComponent();
            CreateGroupUI();
        }

        public void CreateGroupUI()
        {
            foreach (GroupContext Group in AllGroups)
            
                CBGroup.Items.Add(Group.Name);

                CBGroup.Items.Add("Выберите...");
            CBGroup.SelectedIndex = CBGroup.Items.Count - 1;
        }

        public void CreateStudents(List<StudentContext> AllStudents)
        {
            Parent.Children.Clear();
            foreach (StudentContext Student in AllStudents)
                Parent.Children.Add(new Items.Student(Student, this));
        }

        private void SelectGroup(object sender, RoutedEventArgs e)
        {
            if(CBGroup.SelectedIndex != CBGroup.Items.Count - 1)
            {
                int IdGroup = AllGroups.Find(x => x.Name == CBGroup.SelectedItem).Id;
                CreateStudents(AllStudents.FindAll(x => x.IdGroup == IdGroup));
            }
        }
        private void SelectStudent(object sender, KeyEventArgs e)
        {
            List<StudentContext> SearchStudent = AllStudents();
            if (CBGroup.SelectedIndex != CBGroup.Items.Count - 1)
            {
                int IdGroup = AllGroups.Find(x => x.Name == CBGroup.SelectedItem).Id;
                SearchStudent = AllStudents.FindAll(x => x.IdGroup == IdGroup);
            }
            CreateStudents(SearchStudent.FindAll(x => $"{x.Lastname} {x.Firstname}".Contains(TBFIO.Text)));
        }
    }
}
