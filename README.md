# HeadDistanceTravelledCustom  
denpadokeiさんが作成した「HeadDistanceTravelled」に機能を追加したカスタム版です。  
アセンブリ名は元と同じ「HeadDistanceTravelled.dll」です。  
元レポジトリ：https://github.com/denpadokei/HeadDistanceTravelled  

デフォの状態では元の機能部分はそのままで使用可能です。  

## 追加機能  
### 機能①  
譜面プレイ終了時「%userprofile%\appdata\LocalLow\Hyperbolic Magnetism\Beat Saber\」フォルダに「HMDDistanceResult.txt」ファイルを作成します。  
OBSのテキストソースで表示すると、譜面プレイ終了時にプレイ記録を表示できます。  
内容：前プレイの距離：〇〇m　今回の総距離：〇〇m  

### 機能②  
譜面プレイ中のDistance表示を頭の上から別の場所に固定表示できます。  

## 設定ファイル詳細  
設定ファイルは「UserData」フォルダに「HeadDistanceTravelledCustom.json」にあります。  
存在しない場合、初期設定ファイルを作成します。  

StartDt:null  
　→nullの場合、総距離がゲーム起動からの合計、日付を入力した場合、指定した日付以降の合計  
　　再起動で途切れてしまった場合などに、指定して起動すると前回起動時の距離も合算可能です。  
　　日付を入力する際はダブルクォーテーションで括ってください。  
　　例："2024/8/11" → 2024/8/11 以降のデータ全て  
　　　　"2024/8/11 12:30:00" → 2024/8/11 12:30:00 以降のデータ全て  

ResultFormat:"前プレイの距離：{1}m　今回の総距離：{0}m"  
　→「HMDDistanceResult.txt」に出力するフォーマット形式  
　{0}：今回の総距離が挿入されます。  
　{1}：前プレイ距離が挿入されます。  
　その他文字列はそのまま出力されます。  
　例：「前プレイの距離：{1}m」にした場合は、今回の総距離は表示されません。  

HiddenPlaying:false　※0.1.1 追加  
　→ trueにした場合、プレイ開始時に「HMDDistanceResult.txt」を空白にします。  
　　メニューに戻ると「HMDDistanceResult.txt」が入力されます。  
　　※プレイ中、OBSに「HMDDistanceResult.txt」を表示したくない場合、シーン変更しなくても対応できます。  

HDTPosFix:false  
　→プレイ中の距離表示を固定するかのフラグ  
　　false→通常の状況（頭の上に追従します）  
　　true→以下プロパティで指定した座標に固定します。  
HDTPosX:0.0  
HDTPosY:0.1  
HDTPosZ":1.2  
→HDTPosFixをTrueに設定した場合の距離表示の座標  
　初期の状態で正面下部に表示します。  

## 注意事項
「HMDDistanceResult.txt」及び「HeadDistanceTravelledCustom.json」が指定のフォルダに存在しない場合は
1曲プレイし、終了後に確認してみてください。

## 変更履歴
0.1.1
* HeadDistanceTravelled-0.1.1-bs1.20.0 対応版
* HeadDistanceTravelledCustom.json のインデント対応  
※ファイルが既に存在する場合は、設定そのままにインデント対応版に変換されます。  
* 「HeadDistanceTravelledCustom.json」に”HiddenPlaying”プロパティの追加。  
※ファイルが既に存在する場合は、falseで追加されます。  

0.1.0
* 初期ビルド
