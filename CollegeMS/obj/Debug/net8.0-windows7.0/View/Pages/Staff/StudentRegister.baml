   M S B A M L   `   `   `  ����D  @CollegeMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CollegeMS.View.Pages.StaffCollegeMS.View.Pages.Staff  5      I)clr-namespace:CollegeMS.View.UserControlsCollegeMS.View.UserControls  5      0    *CollegeMS.View.Pages.Staff.StudentRegister   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:CollegeMS.View.Pages.Staff     5      BuserControls)clr-namespace:CollegeMS.View.UserControls     5         staffViewModel  � DataContext#  [  5
       N� Title$ DoctoreRegister��5      .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      .+�5   
   *   $CollegeMS.View.UserControls.TitleBar  �� 5   
   $��1��6    K� ZIndex$ 0��6   ._�5      �� $��/Assets/Createdoctor.jpg��6   $
��Fill=�66   5      �� 5   
   $��1��6   $��Enter Student Data��6"   $��35(�6<   $
��Bold"�6J   
���   �$	��Top=�6p   $��Center=�6�   �� 5   
   $��1��6   $��Student Name��6"     
TEXT_BLOCK#��[ 66   $��230,143,480,262q�6Z   �� 5   
   $��1��6   $��Level��6!   #��[ 6.   $	��100��6R   $��230,201,470,204q�6^   �� 5   
   $��1��6   $��Password��6!   #��[ 61   $��235,277,475,128q�6U   �� 5    
   $��1��6d     textboxx#��[ 6q   $��334,134,306,251q�6�   ��6   �� *Student.Name+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5!   
   $��1��6e   #��[ 6r   $��335,193,305,192q�6�   ��6   �� *Student.Level+$ TwoWay=�$ PropertyChanged=�6�   �� 5"   
   $��1��6h   #��[ 6u   $��335,268,305,117q�6�   ��6   �� *Student.Password+$ TwoWay=�$ PropertyChanged=�6�   �� 5$   
   $��1��6   $��Create Student��6   $��12(�67   $
��Bold"�6E   $��44,140,654,249q�6W   ${�False��6o     RoundButtonWhite#��[ 6�    � Cursor$
 Hand��6�   �� 5'   
   $��1��6   $��	Birthdate��6!   #��[ 62   $��538,143,172,262q�6V   �� 5(   
   $��1��6   $��Email��6!   #��[ 6.   $��538,204,172,201q�6R   (  "System.Windows.Controls.DatePicker  5)   
   $��1��6r   $��628,138,42,255q�6�      SelectedDate 6   �� *Student.BirthDate+$ TwoWay=�$ PropertyChanged=�6�   �� 5*   
   $��1��6e   #��[ 6r   $��616,192,24,193q�6�   ��6   �� *Student.Email+$ TwoWay=�$ PropertyChanged=�6�   �� 5-   
   $��1��65   $
��Save��6B     	triggerrr#��[ 6R   $��664,377,26,10q�6v   ��6   �� *RegisterStudent+6v   �� 5.   
   $��DashBoardStaff��66   $��1��6X   $	��↩��6e   $��20(�6q   
�������#��[ 6�   $��Bottom=�6�   $
��Left=�6�   $��	40,0,0,36q�6�   ��6   �� *navigationComand+6�   �� 5/   
   $��1��6   $��Parent Phone ��6!   #��[ 66   $	��100��6Z   $��514,277,186,128q�6f   �� 50   
   $��1��6k   #��[ 6x   $��614,268,26,117q�6�   ��6   �� *Student.ParentPhone+$ TwoWay=�$ PropertyChanged=�6�   51      52      