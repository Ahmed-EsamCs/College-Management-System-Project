   M S B A M L   `   `   `  ����D  @CollegeMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CollegeMS.View.Pages.DoctorCollegeMS.View.Pages.Doctor  5      I)clr-namespace:CollegeMS.View.UserControlsCollegeMS.View.UserControls  5      +    %CollegeMS.View.Pages.Doctor.Dashboard   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:CollegeMS.View.Pages.Doctor     5      BuserControls)clr-namespace:CollegeMS.View.UserControls     5         doctorViewModel  � DataContext#  [  5
       N� Title$ 	Dashboard��5      .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      .+�5   
   *   $CollegeMS.View.UserControls.TitleBar  � 5   
   $��1��6   .+�5      �� ._�5      �� $%��/Assets/doctormenu2modified.jpg��6   $
��Fill=�6A   5      �� 5      $��Doctor Dashboard��6   
�������$��35(�6C   $
��Bold"�6Q   $	��Top=�6c   $
��Left=�6{   $��Segoe UI)�6�   $��
253,40,0,0q�6�   �� 5      $��Students��6   $��StudentsDataDoctor��6M   $��86,267,614,120q�6s     ButtonTransparent#��[ 6�   $
{�True��6�   ��6(   �� *navigationComand+6�   �� 5      $y�	Collapsed=�6   $��Grades��6,   $��194,251,496,136q�6=   #��[ 6V   $
{�True��6�   �� 5      $y�	Collapsed=�6   $��
Attendance��6,   $��348,251,342,136q�6A   #��[ 6Z   $
{�True��6�   �� 5      $��Courses��6   $��AllCoursesDoctor��6L   $��350,268,350,119q�6p   #��[ 6�   $
{�True��6�   ��6'   �� *navigationComand+6�   �� 5      $��	Your Data��6   $��
DoctorData��6P   $��604,268,96,119q�6o   #��[ 6�   $
{�True��6�   ��6+   �� *navigationComand+6�   �� 5       $y�	Collapsed=�6   $	��↩��6,   $��LogIn��6^   $��20(�6w     	triggerrr#��[ 6�   $��39,377,651,10q�6�   $
{�True��6�   ��69   �� *navigationComand+6�   5!      5"      5#      