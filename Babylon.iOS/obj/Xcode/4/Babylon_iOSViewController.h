// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface Babylon_iOSViewController : UIViewController {
	UILabel *_TextLabel;
	UILabel *_TranslationLabel;
}

@property (nonatomic, retain) IBOutlet UILabel *TextLabel;

@property (nonatomic, retain) IBOutlet UILabel *TranslationLabel;

- (IBAction)PlaySoundButtonClicked:(id)sender;

- (IBAction)NextButtonClicked:(id)sender;

- (IBAction)PrevButtonClicked:(id)sender;

- (IBAction)playButtonClicked:(id)sender;

@end
