   M S B A M L   `   `   `  ����D  @CollegeMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:CollegeMS.View.Pages.StudentCollegeMS.View.Pages.Student  5      I)clr-namespace:CollegeMS.View.UserControlsCollegeMS.View.UserControls  5      +    %CollegeMS.View.Pages.Student.MyCourse   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:CollegeMS.View.Pages.Student     5      BuserControls)clr-namespace:CollegeMS.View.UserControls     5        N� Title$  MyCourse��5	         studentViewModel � DataContext# [  5
      .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      .+�5   
   *   $CollegeMS.View.UserControls.TitleBar  � 5   
   $��1��6   .+�5      �� ._�5      �� $��/Assets/regist.png��6   $
��Fill=�64   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ 
RegistGrid��5        SelectionUnit$ FullRow=�6      
IsReadOnly$
 True��6�     RowHover   RowStyle# [ 6�   $
��Left=�6�   $��Center=�6�   $	��500��6�   $	��250��6�      HeadersVisibility$ Column=�6     CanUserResizeColumns$ False��6:  	   AutoGenerateColumns$	 False��6X  
   CanUserAddRows$
 False��6t     CanUserDeleteRows$ False��6�     CanUserReorderColumns$ False��6�     CanUserResizeRows$ False��6�     CanUserSortColumns$ False��6�  ���#fdf3f1
���   �$
��Bold"�6!  $��	260,0,0,0q�63  
���   �$��2q�6[  ��60   �� *	Courses+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Course��6)     HeaderBG   HeaderStyle# [ 6R      
IsReadOnly$
 True��6z      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Name+6�     5      $ CH��6)   # [ 6T   $
 True��6|   $ * 6�    65   �� *
CreditHour+6�   4  .System.Windows.Controls.DataGridCheckBoxColumn  5         
Visibility$ 	Collapsed=�6-   $ Add/Remove Course��6D   # [ 6�   $ False��6�   $ * 6�    6_   �� *	AddRemove+$ TwoWay=�$ PropertyChanged=�6�   5!      �� 5$      $	��↩��6   $��DashBoardStudent��6F   $��20(�6j     	triggerrr#��[ 6x   $��35,367,655,20q�6�   ��6!   �� *navigationComand+6�   �� 5%      $��GPA Calculation��6   $��GPACalculate��6T   $��12(�6t   #��[ 6�   $��35,318,655,69q�6�   ��6/   �� *navigationComand+6�   �� 5&      $��1��6   $��
My Courses��6"   $��12(�67   $
��Bold"�6E   $��44,140,654,249q�6W   ${�False��6o     RoundButtonWhite#��[ 6�    � Cursor$
 Hand��6�   5'      5(      5)      