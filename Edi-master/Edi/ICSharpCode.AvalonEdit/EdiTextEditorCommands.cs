﻿namespace ICSharpCode.AvalonEdit.Edi
{
  using System.Windows.Input;

  /// <summary>
  /// Static class that contains the commands that can be executed by the <seealso cref="EdiTextEditor"/> control.
  /// </summary>
  public static class EdiTextEditorCommands
  {
    /// <summary>
    /// The Collapse all folds commmand folds all text folds (if any) such that users
    /// can get an overview on the presented text (using a top to bottom approach).
    /// </summary>
    public static readonly RoutedCommand FoldsCollapseAll = new RoutedCommand("CollapseAllFolds", typeof(TextEditor)
      ////, new InputGestureCollection { new KeyGesture(Key.D, ModifierKeys.Control) }
      );

    /// <summary>
    /// The Expand all folds commmand unfolds all text folds (if any) such that users
    /// can read all text items in a given text without having to worry about foldings.
    /// </summary>
    public static readonly RoutedCommand FoldsExpandAll = new RoutedCommand("CollapseAllFolds", typeof(TextEditor)
      ////, new InputGestureCollection { new KeyGesture(Key.D, ModifierKeys.Control) }
      );

    /// <summary>
    /// Show Print Document Dialog and allow the user to print the current document.
    /// </summary>
    public static readonly RoutedCommand PrintDocument = new RoutedCommand("PrintDocument", typeof(TextEditor)
      ////, new InputGestureCollection { new KeyGesture(Key.D, ModifierKeys.Control) }
      );
  }
}
