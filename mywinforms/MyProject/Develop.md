# 開発メモ

## 手順

1. テンプレートからプロジェクトを作成する
2. モデルの構築
3. UI の構築

## モデル

1. ViewModel.cs にデータ項目を追加する。
2. ViewModel.Data.cs Reset() にデータ初期値を追加する。
3. ViewModel.Data.cs CopyFrom() にデータ複製を追加する。
4. ViewModel.Validates.cs に検証処理を追加する。
5. ViewModel.Logic.cs に処理を追加する。

## UI

1. MainForm.Designer.cs に UI コントロールを追加する。
2. MainForm.Designer.cs で画面表示をデザインする。
3. MainForm.Menus.cs でメニューをデザインする。
4. MainFormSettings.cs にUI関係をデータバインディングを追加する。
5. MainForm.DataBindings.cs SetBinding() にデータバインディングを追加する。
6. MainForm.Designer.cs SetData() にデータソース準備を追加する。
7. MainForm.Views.cs に表示処理を追加する。
8. MainForm.Events.cs にイベント処理を追加する。
9. MainForm.Events.cs InitializeEvents() にイベント初期化を追加する。
10. MainForm.Validates.cs に検証処理を追加する。
11. MainForm.Validates.cs InitializeValidation() に検証処理初期化を追加する。
12. MainForm.Validates.cs ValidateData() に全体検証処理を追加する。
