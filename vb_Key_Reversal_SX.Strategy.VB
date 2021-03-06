﻿Imports PowerLanguage
Imports System
Imports System.Runtime.CompilerServices

Namespace PowerLanguage.Strategy
    <IOGMode(IOGMode.Disabled)> _
    Public Class vb_Key_Reversal_SX
        Inherits SignalObject
        ' Methods
        Public Sub New(ByVal ctx As Object)
            MyBase.New(ctx)
            Me.Length = 1
        End Sub

        Protected Overrides Sub CalcBar()
            m_lowest.Value = Bars.Low.Lowest(Length)
            If (PublicFunctions.DoubleLess(MyBase.Bars.Low.Item(0), m_lowest.Item(1)) AndAlso PublicFunctions.DoubleGreater(MyBase.Bars.Close.Item(0), MyBase.Bars.Close.Item(1))) Then
                Me.m_KeyRevSX.Send()
            End If
        End Sub

        Protected Overrides Sub Create()
            m_lowest = New VariableSeries(Of Double)(Me)
            Me.m_KeyRevSX = MyBase.OrderCreator.MarketNextBar(New SOrderParameters(Contracts.Default, "KeyRevSX", EOrderAction.BuyToCover, OrderExit.FromAll))
        End Sub


        ' Properties
        <Input> _
        Public Property Length As Integer


        ' Fields
        Private m_lowest As VariableSeries(Of Double)
        Private m_KeyRevSX As IOrderMarket
    End Class
End Namespace
