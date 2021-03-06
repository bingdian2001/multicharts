﻿Imports PowerLanguage
Imports System
Imports System.Drawing
Imports System.Runtime.CompilerServices

Namespace PowerLanguage.Indicator
    Public Class vb_Spread__Diff
        Inherits IndicatorObject
        ' Methods
        Public Sub New(ByVal ctx As Object)
            MyBase.New(ctx)
        End Sub

        Protected Overrides Sub CalcBar()
            Me.Plot1.Set(0, (Me.dataseries1.Item(0) - Me.dataseries2.Item(0)))
        End Sub

        Protected Overrides Sub Create()
            Me.Plot1 = MyBase.AddPlot(New PlotAttributes("SprdDiff", EPlotShapes.Line, Color.Blue, Color.Empty, 0, 0, True))
        End Sub

        Protected Overrides Sub StartCalc()
            Me.dataseries1 = MyBase.Bars.Close
            Me.dataseries2 = MyBase.BarsOfData(2).Close
        End Sub


        ' Properties
        Private Property dataseries1 As ISeries(Of Double)

        Private Property dataseries2 As ISeries(Of Double)


        ' Fields
        Private Plot1 As IPlotObject
    End Class
End Namespace
