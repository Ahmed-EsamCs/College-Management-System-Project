   M S B A M L   `   `   `  ����D  @CollegeMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CollegeMS.View.Pages.StaffCollegeMS.View.Pages.Staff  5      I)clr-namespace:CollegeMS.View.UserControlsCollegeMS.View.UserControls  5
      -    'CollegeMS.View.Pages.Staff.CreateCourse   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:CollegeMS.View.Pages.Staff     5      BuserControls)clr-namespace:CollegeMS.View.UserControls     5
         staffViewModel  � DataContext#  [  5	       N� Title$ CreateCourse��5      .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      .+�5   
   *   $CollegeMS.View.UserControls.TitleBar  �� 5   
   $��1��6    K� ZIndex$ 0��6   ._�5      �� $��/Assets/Createdoctor.jpg��6   $
��Fill=�66   5      �� 5   
   $��1��6   $��Enter Course Data��6"   $��35(�6;   $
��Bold"�6I   
���   �$	��Top=�6o   $��Center=�6�   �� 5   
   $��1��6   $��Course Name��6"     
TEXT_BLOCK#��[ 65   $��230,143,480,262q�6Y   �� 5   
   $��1��6   $��Credit Hour��6!   #��[ 64   $	��100��6X   $��514,147,186,258q�6d   �� 5   
   $��1��6c     textboxx#��[ 6p   $��334,134,306,251q�6�   ��6   �� *course.Name+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5    
   $��1��6i   #��[ 6v   $��614,134,26,251q�6�   ��6   �� *course.CreditHour+$ TwoWay=�$ PropertyChanged=�6�   �� 5"   
   $��1��6   $��Create Course��6   $��12(�66   $
��Bold"�6D   $��44,140,654,249q�6V   ${�False��6n     RoundButtonWhite#��[ 6�    � Cursor$
 Hand��6�   �� 5'   
   $��1��6/   $
��Save��6<     	triggerrr#��[ 6L   $��664,377,26,10q�6p   ��6   �� *	AddCourse+6p   �� 5(   
   $��DashBoardStaff��66   $��1��6X   $	��↩��6e   $��20(�6q   
�������#��[ 6�   $��Bottom=�6�   $
��Left=�6�   $��	40,0,0,36q�6�   ��6   �� *navigationComand+6�   5)      5+      