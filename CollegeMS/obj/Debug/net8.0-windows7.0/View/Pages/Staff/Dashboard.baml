   M S B A M L   `   `   `  ����D  @CollegeMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CollegeMS.View.Pages.StaffCollegeMS.View.Pages.Staff  5      I)clr-namespace:CollegeMS.View.UserControlsCollegeMS.View.UserControls  5      *    $CollegeMS.View.Pages.Staff.Dashboard   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:CollegeMS.View.Pages.Staff     5      BuserControls)clr-namespace:CollegeMS.View.UserControls     5         staffViewModel  � DataContext#  [  5
       N� Title$ 	Dashboard��5      .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      .+�5   
   *   $CollegeMS.View.UserControls.TitleBar  �� 5   
   $��1��6    K� ZIndex$ 0��6   ._�5      �� $$��\Assets\dashboard_modified.png��6   $
��Fill=�6<   5      �� 5   
   $��1��6   $��College Management System��6!   
�������$��35(�6U   $
��Bold"�6c   $	��Top=�6u   $��Center=�6�   $��Segoe UI)�6�   5      �� 5   
   $��AllStudents��66   $��1��6U   $��Students��6b   $��37,271,663,116q�6u     ButtonTransparent#��[ 6�   ��6   �� *navigationComand+6�   �� 5   
   $��
AllDoctors��66   $��1��6T   $��Doctors��6a   $��200,271,500,116q�6s   #��[ 6�   ��6   �� *navigationComand+6�   �� 5   
   $��AllCoursesStaff��66   $��1��6Y   $��Courses��6f   $��364,271,336,116q�6z   #��[ 6�    J� RenderTransformOrigin$ 
0.53,0.561&�6�   ��6   �� *navigationComand+6�   �� 5!   
   $��	AddDoctor��66   $��1��6S   $��Register Doctor��6`   $��519,271,181,116q�6z   #��[ 6�   ��6   �� *navigationComand+6�   �� 5"   
   $��
AddStudent��66   $��1��6T   $��Register Student��6a   $��668,271,32,116q�6|   #��[ 6�   ��6   �� *navigationComand+6�   5$      5%      