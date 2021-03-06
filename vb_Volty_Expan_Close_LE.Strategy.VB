﻿Imports PowerLanguage
Imports PowerLanguage.Function
Imports System
Imports System.Runtime.CompilerServices

Namespace PowerLanguage.Strategy
    <IOGMode(IOGMode.Disabled)> _
    Public Class vb_Volty_Expan_Close_LE
        Inherits SignalObject
        ' Methods
        Public Sub New(ByVal ctx As Object)
            MyBase.New(ctx)
            Me.NumAtrs = 0.75
            Me.Length = 5
        End Sub

        Protected Overrides Sub CalcBar()
            Me.m_VltClsLE.Send((MyBase.Bars.Close.Item(0) + (Me.AverageTrueRange(Me.Length) * Me.NumAtrs)))
        End Sub

        Protected Overrides Sub Create()
            Me.m_VltClsLE = MyBase.OrderCreator.Stop(New SOrderParameters(Contracts.Default, "VltClsLE", EOrderAction.Buy))
        End Sub


        ' Properties
        <Input> _
        Public Property Length As Integer

        <Input()> _
        Public Property NumAtrs As Double


        ' Fields
        Private m_VltClsLE As IOrderPriced
    End Class
End Namespace
