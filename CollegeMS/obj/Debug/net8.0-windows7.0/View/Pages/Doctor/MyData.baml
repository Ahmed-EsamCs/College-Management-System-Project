   M S B A M L   `   `   `  ����D  @CollegeMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CollegeMS.View.Pages.DoctorCollegeMS.View.Pages.Doctor  5      I)clr-namespace:CollegeMS.View.UserControlsCollegeMS.View.UserControls  5      (    "CollegeMS.View.Pages.Doctor.MyData   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:CollegeMS.View.Pages.Doctor     5      BuserControls)clr-namespace:CollegeMS.View.UserControls     5         doctorViewModel  � DataContext#  [  5
       N� Title$ MyData��5      .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      .+�5   
   *   $CollegeMS.View.UserControls.TitleBar  �� 5   
   $��1��6    K� ZIndex$ 0��6   ._�5      �� $��0q�6   $��Asse0��6   $
��Fill=�6.   $��2��6=   5      �� 5   
   $��0q�6   $"��/Assets/Doctor DataFinal.jpg��6   $
��Fill=�6A   $��1��6P   �� 5   
   $��1��6   $��Doctor Name :��6!     
TEXT_BLOCK#��[ 66   $��280,43,430,362q�6Z   �� 5   
   $��1��6   $��	Faculty :��6!   #��[ 62   $��280,94,430,311q�6V   �� 5   
   $��1��6   $��Email :��6!   #��[ 60   $��535,94,175,311q�6T   �� 5   
   $��1��6   $��Birthdate :��6!   #��[ 64   $��287,160,423,245q�6X   �� 5   
   $��1��6   $��Doctor ID :��6!   #��[ 64   $��535,43,175,362q�6X   �� 5#   
   $��1��6   #��[ 6>   $��374,44,336,361q�6b   ��6!   �� *doctor.Name+6b   �� 5$   
   $��1��6   $'��!Computing and Information Systems��6!   $	��NaN��6J   $��8(�6V   #��[ 6c   $��335,99,307,306q�6�   �� 5%   
   $��1��6   $	��NaN��6?   #��[ 6K   $��579,94,63,311q�6o   ��6!   �� *doctor.Email+6o   �� 5&   
   $��1��6   #��[ 6E   $��364,160,381,245q�6i    J� RenderTransformOrigin$ 0.5,0.5&�6�   ��6!   �� *doctor.BirthDate+z�5'      V� 5(      .~�5)      ��  �� ScaleX$ 1Q�6%   �� 5*      �� 5+      T� 5,      5-      5/      �� 50   
   $��1��6   #��[ 6<   $��604,44,106,361q�6`   ��6!   �� *	doctor.id+6`   �� 51   
   $��1��6   #��[ 6E   $��593,159,117,246q�6i   ��6!   �� *doctor.Course.Name+6i   �� 54   
   $	��↩��6   $��DashBoardDoctor��6C   $��20(�6f     	triggerrr#��[ 6t   $��33,359,657,28q�6�   $
{�True��6�   $��1��6�   ��6   �� *navigationComand+6�   �� 55   
   $��1��6   #��[ 6!   $��535,159,175,246q�6E   $��Course :��6^   57      58      