   M S B A M L   `   `   `  ����D  @CollegeMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:CollegeMS.View.PagesCollegeMS.View.Pages  5      I)clr-namespace:CollegeMS.View.UserControlsCollegeMS.View.UserControls  5           CollegeMS.View.Pages.Login   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:CollegeMS.View.Pages     5      BuserControls)clr-namespace:CollegeMS.View.UserControls     5         loginViewModel  � DataContext#  [  5
       N� Title$ Login��5      .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      .+�5   
   *   $CollegeMS.View.UserControls.TitleBar  �� 5   
   $��1��6   $��
0,-1,0,-12q�6   $)��#/Assets/Login panel 144444final.jpg��61   $
��Fill=�6^   � 5   
   $��1��6   $��	9,-3,-9,3q�6   $��2��6/    � ColumnDefinitions 5      �� 5      $	��123 �6#   �� 5      $	��200 �6#   �� 5      $
��477* �6#    5      �� 5      $	��182 �6    �� 5      $��33 �6    �� 5       $��44 �6    �� 5!      $��14 �6    �� 5"      $	��120 �6    �� 5#      $��41 �6    .+�5%      ��  �� CornerRadius$	 100��5&      $��1��5'      $��4��5(      $��Center=�5)      $	��190��5*      $	��118��5+      $��Center=�5,      ._�5-      �� $��Login��63    	 Login#��[ 6D   $��40��6c   $��19,28,19,50q�6o   ��6   �� *Login+6o   5/      �� 50      $ 9��51      $��1��52      $��1��53      ���#f2eceb$��1q�55      $��Center=�56      $	��162��57      $��29��58      $��0,3,0,1q�6   ._�5;      �� -   5         ��Name$ 	userblock��5;      $��Username��5<      $��Center=�5=      
���   �$
��Left=�5?      $	��225��5@      $��	-69,0,0,0q�6!   $
��Bold"�5A      5E      �� 5G      $ 9��5H      $��1��5I      $��1��5J      
������ $��1q�5L      $��Center=�5M      $	��161��5N      $��29��5O      �� 5T      $ 5��5U      $��1��5V      $��2��5W      ���#f2eceb$��1q�5Y      $��Center=�5Z      $	��162��5[      $��30��6   $��Center=�6)   ._�5\      �� -   5        $ 	passblock��5\      $��	-67,0,0,0q�5^      $��Password��5_      $��Center=�5`      
���   �$
��Left=�5b      $	��228��5c      $
��Bold"�5d      5e      �� 5f      -   5         ��Name$ Username��5f      $	��161��5g      $��29��5h      $��1��5j      $��1��6!   $��	20,3,19,1q�5k      $��Center=�5l      $
��Bold"�5m      ��5i      �� *
userNmae+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5m      �� 5o      -   5        $ Password��5o      $	��161��5p      $��29��5q      $��1��5s      $��2��5t      $��	20,2,19,1q�5u      $��Center=�5v      $
��Bold"�5w      ��5r      �� *
password+$ TwoWay=�$ PropertyChanged=�5w      5z      5{      5|      