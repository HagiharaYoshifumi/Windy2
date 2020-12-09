Imports System.Windows.Forms.Design

Namespace Common
    Friend Class uLabelXDesigner
        Inherits ControlDesigner

        Protected Overrides Sub PostFilterProperties(ByVal _Properties As System.Collections.IDictionary)
            _Properties.Remove("BackColor")
            _Properties.Remove("BackgroundImage")
            _Properties.Remove("BackgroundImageLayout")
            _Properties.Remove("RightToLeft")
            _Properties.Remove("TabStop")
            _Properties.Remove("TabIndex")
            _Properties.Remove("AutoSize")

            MyBase.PostFilterProperties(_Properties)
        End Sub
    End Class
End Namespace
