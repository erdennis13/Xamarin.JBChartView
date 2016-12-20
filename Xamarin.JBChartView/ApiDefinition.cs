using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Xamarin.JBChartView
{
    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    //partial interface Constants
    //{
    //    // extern const CGFloat kJBChartViewDefaultAnimationDuration;
    //    [Field("kJBChartViewDefaultAnimationDuration", "__Internal")]
    //    nfloat kJBChartViewDefaultAnimationDuration { get; }
    //}

    // @protocol JBChartViewDataSource <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface JBChartViewDataSource
    {
        // @optional -(BOOL)shouldExtendSelectionViewIntoHeaderPaddingForChartView:(JBChartView *)chartView;
        [Export("shouldExtendSelectionViewIntoHeaderPaddingForChartView:")]
        bool ShouldExtendSelectionViewIntoHeaderPaddingForChartView(JBChartView chartView);

        // @optional -(BOOL)shouldExtendSelectionViewIntoFooterPaddingForChartView:(JBChartView *)chartView;
        [Export("shouldExtendSelectionViewIntoFooterPaddingForChartView:")]
        bool ShouldExtendSelectionViewIntoFooterPaddingForChartView(JBChartView chartView);
    }

    // @protocol JBChartViewDelegate <NSObject>
    [BaseType(typeof(NSObject))]
    [Model]
    interface JBChartViewDelegate
    {
    }

    // @interface JBChartView : UIView
    [BaseType(typeof(UIView))]
    interface JBChartView
    {
        // @property (nonatomic, weak) id<JBChartViewDataSource> _Nullable dataSource;
        [NullAllowed, Export("dataSource", ArgumentSemantic.Weak)]
        JBChartViewDataSource DataSource { get; set; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        JBChartViewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<JBChartViewDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic, strong) UIView * footerView;
        [Export("footerView", ArgumentSemantic.Strong)]
        UIView FooterView { get; set; }

        // @property (nonatomic, strong) UIView * headerView;
        [Export("headerView", ArgumentSemantic.Strong)]
        UIView HeaderView { get; set; }

        // @property (assign, nonatomic) CGFloat headerPadding;
        [Export("headerPadding")]
        nfloat HeaderPadding { get; set; }

        // @property (assign, nonatomic) CGFloat footerPadding;
        [Export("footerPadding")]
        nfloat FooterPadding { get; set; }

        // @property (assign, nonatomic) CGFloat minimumValue;
        [Export("minimumValue")]
        nfloat MinimumValue { get; set; }

        // @property (assign, nonatomic) CGFloat maximumValue;
        [Export("maximumValue")]
        nfloat MaximumValue { get; set; }

        // -(void)resetMinimumValue;
        [Export("resetMinimumValue")]
        void ResetMinimumValue();

        // -(void)resetMaximumValue;
        [Export("resetMaximumValue")]
        void ResetMaximumValue();

        // @property (assign, nonatomic) JBChartViewState state;
        [Export("state", ArgumentSemantic.Assign)]
        JBChartViewState State { get; set; }

        // -(void)reloadData;
        [Export("reloadData")]
        void ReloadData();

        // -(void)setState:(JBChartViewState)state animated:(BOOL)animated force:(BOOL)force callback:(void (^)())callback;
        [Export("setState:animated:force:callback:")]
        void SetState(JBChartViewState state, bool animated, bool force, Action callback);

        // -(void)setState:(JBChartViewState)state animated:(BOOL)animated callback:(void (^)())callback;
        [Export("setState:animated:callback:")]
        void SetState(JBChartViewState state, bool animated, Action callback);

        // -(void)setState:(JBChartViewState)state animated:(BOOL)animated;
        [Export("setState:animated:")]
        void SetState(JBChartViewState state, bool animated);
    }

    // @interface JBChartVerticalSelectionView : UIView
    [BaseType(typeof(UIView))]
    interface JBChartVerticalSelectionView
    {
        // @property (nonatomic, strong) UIColor * bgColor;
        [Export("bgColor", ArgumentSemantic.Strong)]
        UIColor BgColor { get; set; }
    }

    // @protocol JBBarChartViewDataSource <JBChartViewDataSource>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface JBBarChartViewDataSource : JBChartViewDataSource
    {
        // @required -(NSUInteger)numberOfBarsInBarChartView:(JBBarChartView *)barChartView;
        [Abstract]
        [Export("numberOfBarsInBarChartView:")]
        nuint NumberOfBarsInBarChartView(JBBarChartView barChartView);

        // @optional -(UIView *)barChartView:(JBBarChartView *)barChartView barViewAtIndex:(NSUInteger)index;
        [Export("barChartView:barViewAtIndex:")]
        UIView BarChartView(JBBarChartView barChartView, nuint index);
    }

    // @protocol JBBarChartViewDelegate <JBChartViewDelegate>
    [BaseType(typeof(NSObject))]
    [Model]
    interface JBBarChartViewDelegate : JBChartViewDelegate
    {
        // @required -(CGFloat)barChartView:(JBBarChartView *)barChartView heightForBarViewAtIndex:(NSUInteger)index;
        [Abstract]
        [Export("barChartView:heightForBarViewAtIndex:")]
        nfloat HeightForBarViewAtIndex(JBBarChartView barChartView, nuint index);

        // @optional -(void)barChartView:(JBBarChartView *)barChartView didSelectBarAtIndex:(NSUInteger)index touchPoint:(CGPoint)touchPoint;
        [Export("barChartView:didSelectBarAtIndex:touchPoint:")]
        void DidSelectBarAtIndex(JBBarChartView barChartView, nuint index, CGPoint touchPoint);

        // @optional -(void)barChartView:(JBBarChartView *)barChartView didSelectBarAtIndex:(NSUInteger)index;
        [Export("barChartView:didSelectBarAtIndex:")]
        void DidSelectBarAtIndex(JBBarChartView barChartView, nuint index);

        // @optional -(void)didDeselectBarChartView:(JBBarChartView *)barChartView;
        [Export("didDeselectBarChartView:")]
        void DidDeselectBarChartView(JBBarChartView barChartView);

        // @optional -(UIColor *)barChartView:(JBBarChartView *)barChartView colorForBarViewAtIndex:(NSUInteger)index;
        [Export("barChartView:colorForBarViewAtIndex:")]
        UIColor ColorForBarViewAtIndex(JBBarChartView barChartView, nuint index);

        // @optional -(CAGradientLayer *)barGradientForBarChartView:(JBBarChartView *)barChartView;
        [Export("barGradientForBarChartView:")]
        CAGradientLayer BarGradientForBarChartView(JBBarChartView barChartView);

        // @optional -(UIColor *)barSelectionColorForBarChartView:(JBBarChartView *)barChartView;
        [Export("barSelectionColorForBarChartView:")]
        UIColor BarSelectionColorForBarChartView(JBBarChartView barChartView);

        // @optional -(CGFloat)barPaddingForBarChartView:(JBBarChartView *)barChartView;
        [Export("barPaddingForBarChartView:")]
        nfloat BarPaddingForBarChartView(JBBarChartView barChartView);
    }

    // @interface JBBarChartView : JBChartView
    [BaseType(typeof(JBChartView))]
    interface JBBarChartView
    {
        // @property (nonatomic, weak) id<JBBarChartViewDataSource> _Nullable dataSource;
        [NullAllowed, Export("dataSource", ArgumentSemantic.Weak)]
        JBBarChartViewDataSource DataSource { get; set; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        JBBarChartViewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<JBBarChartViewDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (getter = isInverted, assign, nonatomic) BOOL inverted;
        [Export("inverted")]
        bool Inverted { [Bind("isInverted")] get; set; }

        // -(void)reloadDataAnimated:(BOOL)animated;
        [Export("reloadDataAnimated:")]
        void ReloadDataAnimated(bool animated);

        // @property (readonly, nonatomic) BOOL reloading;
        [Export("reloading")]
        bool Reloading { get; }

        // @property (assign, nonatomic) BOOL showsVerticalSelection;
        [Export("showsVerticalSelection")]
        bool ShowsVerticalSelection { get; set; }

        // -(UIView *)barViewAtIndex:(NSUInteger)index;
        [Export("barViewAtIndex:")]
        UIView BarViewAtIndex(nuint index);
    }

    // @protocol JBGradientBarViewDataSource <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface JBGradientBarViewDataSource
    {
        // @optional -(CGRect)chartViewBoundsForGradientBarView:(JBGradientBarView *)gradientBarView;
        [Export("chartViewBoundsForGradientBarView:")]
        CGRect ChartViewBoundsForGradientBarView(JBGradientBarView gradientBarView);
    }

    // @interface JBGradientBarView : UIView
    [BaseType(typeof(UIView))]
    interface JBGradientBarView
    {
        // @property (nonatomic, weak) id<JBGradientBarViewDataSource> _Nullable dataSource;
        [NullAllowed, Export("dataSource", ArgumentSemantic.Weak)]
        JBGradientBarViewDataSource DataSource { get; set; }

        // @property (nonatomic, strong) CAGradientLayer * gradientLayer;
        [Export("gradientLayer", ArgumentSemantic.Strong)]
        CAGradientLayer GradientLayer { get; set; }
    }

    // @interface JBGradientLineLayer : CAGradientLayer
    [BaseType(typeof(CAGradientLayer))]
    interface JBGradientLineLayer
    {
        // -(instancetype)initWithGradientLayer:(CAGradientLayer *)gradientLayer tag:(NSUInteger)tag filled:(BOOL)filled currentPath:(UIBezierPath *)currentPath;
        [Export("initWithGradientLayer:tag:filled:currentPath:")]
        IntPtr Constructor(CAGradientLayer gradientLayer, nuint tag, bool filled, UIBezierPath currentPath);

        // @property (readonly, nonatomic) NSUInteger tag;
        [Export("tag")]
        nuint Tag { get; }

        // @property (readonly, nonatomic) BOOL filled;
        [Export("filled")]
        bool Filled { get; }

        // @property (nonatomic, strong) UIBezierPath * currentPath;
        [Export("currentPath", ArgumentSemantic.Strong)]
        UIBezierPath CurrentPath { get; set; }

        // @property (readonly, nonatomic) CGFloat alpha;
        [Export("alpha")]
        nfloat Alpha { get; }
    }

    // @interface JBLineChartDotView : UIView
    [BaseType(typeof(UIView))]
    interface JBLineChartDotView
    {
        // -(id)initWithRadius:(CGFloat)radius;
        [Export("initWithRadius:")]
        IntPtr Constructor(nfloat radius);
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    //partial interface Constants
    //{
    //    // extern const NSInteger kJBLineChartDotsViewUnselectedLineIndex;
    //    [Field("kJBLineChartDotsViewUnselectedLineIndex", "__Internal")]
    //    nint kJBLineChartDotsViewUnselectedLineIndex { get; }
    //}

    // @interface JBLineChartDotsView : UIView
    [BaseType(typeof(UIView))]
    interface JBLineChartDotsView
    {
        // @property (assign, nonatomic) id<JBLineChartDotsViewDataSource> dataSource;
        [Export("dataSource", ArgumentSemantic.Assign)]
        JBLineChartDotsViewDataSource DataSource { get; set; }

        // @property (assign, nonatomic) NSInteger selectedLineIndex;
        [Export("selectedLineIndex")]
        nint SelectedLineIndex { get; set; }

        // @property (nonatomic, strong) NSDictionary * dotViewsDict;
        [Export("dotViewsDict", ArgumentSemantic.Strong)]
        NSDictionary DotViewsDict { get; set; }

        // -(void)reloadDataAnimated:(BOOL)animated callback:(void (^)())callback;
        [Export("reloadDataAnimated:callback:")]
        void ReloadDataAnimated(bool animated, Action callback);

        // -(void)reloadDataAnimated:(BOOL)animated;
        [Export("reloadDataAnimated:")]
        void ReloadDataAnimated(bool animated);

        // -(void)reloadData;
        [Export("reloadData")]
        void ReloadData();

        // -(void)setSelectedLineIndex:(NSInteger)selectedLineIndex animated:(BOOL)animated;
        [Export("setSelectedLineIndex:animated:")]
        void SetSelectedLineIndex(nint selectedLineIndex, bool animated);

        // -(UIView *)dotViewForHorizontalIndex:(NSUInteger)horizontalIndex atLineIndex:(NSUInteger)lineIndex;
        [Export("dotViewForHorizontalIndex:atLineIndex:")]
        UIView DotViewForHorizontalIndex(nuint horizontalIndex, nuint lineIndex);
    }

    // @protocol JBLineChartDotsViewDataSource <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface JBLineChartDotsViewDataSource
    {
        // @required -(NSArray *)lineChartLinesForLineChartDotsView:(JBLineChartDotsView *)lineChartDotsView;
        [Abstract]
        [Export("lineChartLinesForLineChartDotsView:")]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] LineChartLinesForLineChartDotsView(JBLineChartDotsView lineChartDotsView);

        // @required -(UIColor *)lineChartDotsView:(JBLineChartDotsView *)lineChartDotsView colorForDotAtHorizontalIndex:(NSUInteger)horizontalIndex atLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartDotsView:colorForDotAtHorizontalIndex:atLineIndex:")]
        UIColor ColorForDotAtHorizontalIndex(JBLineChartDotsView lineChartDotsView, nuint horizontalIndex, nuint lineIndex);

        // @required -(UIColor *)lineChartDotsView:(JBLineChartDotsView *)lineChartDotsView selectedColorForDotAtHorizontalIndex:(NSUInteger)horizontalIndex atLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartDotsView:selectedColorForDotAtHorizontalIndex:atLineIndex:")]
        UIColor SelectedColorForDotAtHorizontalIndex(JBLineChartDotsView lineChartDotsView, nuint horizontalIndex, nuint lineIndex);

        // @required -(CGFloat)lineChartDotsView:(JBLineChartDotsView *)lineChartDotsView dotRadiusForLineAtHorizontalIndex:(NSUInteger)horizontalIndex atLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartDotsView:dotRadiusForLineAtHorizontalIndex:atLineIndex:")]
        nfloat DotRadiusForLineAtHorizontalIndex(JBLineChartDotsView lineChartDotsView, nuint horizontalIndex, nuint lineIndex);

        // @required -(UIView *)lineChartDotsView:(JBLineChartDotsView *)lineChartDotsView dotViewAtHorizontalIndex:(NSUInteger)horizontalIndex atLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartDotsView:dotViewAtHorizontalIndex:atLineIndex:")]
        UIView DotViewAtHorizontalIndex(JBLineChartDotsView lineChartDotsView, nuint horizontalIndex, nuint lineIndex);

        // @required -(BOOL)lineChartDotsView:(JBLineChartDotsView *)lineChartDotsView shouldHideDotViewOnSelectionAtHorizontalIndex:(NSUInteger)horizontalIndex atLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartDotsView:shouldHideDotViewOnSelectionAtHorizontalIndex:atLineIndex:")]
        bool ShouldHideDotViewOnSelectionAtHorizontalIndex(JBLineChartDotsView lineChartDotsView, nuint horizontalIndex, nuint lineIndex);

        // @required -(BOOL)lineChartDotsView:(JBLineChartDotsView *)lineChartDotsView showsDotsForLineAtLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartDotsView:showsDotsForLineAtLineIndex:")]
        bool ShowsDotsForLineAtLineIndex(JBLineChartDotsView lineChartDotsView, nuint lineIndex);

        // @required -(CGFloat)lineChartDotsView:(JBLineChartDotsView *)lineChartDotsView dimmedSelectionDotOpacityAtLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartDotsView:dimmedSelectionDotOpacityAtLineIndex:")]
        nfloat DimmedSelectionDotOpacityAtLineIndex(JBLineChartDotsView lineChartDotsView, nuint lineIndex);
    }

    // @protocol JBLineChartViewDataSource <JBChartViewDataSource>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface JBLineChartViewDataSource : JBChartViewDataSource
    {
        // @required -(NSUInteger)numberOfLinesInLineChartView:(JBLineChartView *)lineChartView;
        [Abstract]
        [Export("numberOfLinesInLineChartView:")]
        nuint NumberOfLinesInLineChartView(JBLineChartView lineChartView);

        // @required -(NSUInteger)lineChartView:(JBLineChartView *)lineChartView numberOfVerticalValuesAtLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartView:numberOfVerticalValuesAtLineIndex:")]
        nuint NumberOfVerticalValuesAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);

        // @optional -(BOOL)lineChartView:(JBLineChartView *)lineChartView showsDotsForLineAtLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:showsDotsForLineAtLineIndex:")]
        bool ShowsDotsForLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);

        // @optional -(BOOL)lineChartView:(JBLineChartView *)lineChartView smoothLineAtLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:smoothLineAtLineIndex:")]
        bool SmoothLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);

        // @optional -(CGFloat)lineChartView:(JBLineChartView *)lineChartView dimmedSelectionOpacityAtLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:dimmedSelectionOpacityAtLineIndex:")]
        nfloat DimmedSelectionOpacityAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);

        // @optional -(CGFloat)lineChartView:(JBLineChartView *)lineChartView dimmedSelectionDotOpacityAtLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:dimmedSelectionDotOpacityAtLineIndex:")]
        nfloat DimmedSelectionDotOpacityAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);

        // @optional -(UIView *)lineChartView:(JBLineChartView *)lineChartView dotViewAtHorizontalIndex:(NSUInteger)horizontalIndex atLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:dotViewAtHorizontalIndex:atLineIndex:")]
        UIView DotViewAtHorizontalIndex(JBLineChartView lineChartView, nuint horizontalIndex, nuint lineIndex);

        // @optional -(BOOL)lineChartView:(JBLineChartView *)lineChartView shouldHideDotViewOnSelectionAtHorizontalIndex:(NSUInteger)horizontalIndex atLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:shouldHideDotViewOnSelectionAtHorizontalIndex:atLineIndex:")]
        bool ShouldHideDotViewOnSelectionAtHorizontalIndex(JBLineChartView lineChartView, nuint horizontalIndex, nuint lineIndex);
    }

    // @protocol JBLineChartViewDelegate <JBChartViewDelegate>
    [BaseType(typeof(NSObject))]
    [Model]
    interface JBLineChartViewDelegate : JBChartViewDelegate
    {
        // @required -(CGFloat)lineChartView:(JBLineChartView *)lineChartView verticalValueForHorizontalIndex:(NSUInteger)horizontalIndex atLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartView:verticalValueForHorizontalIndex:atLineIndex:")]
        nfloat VerticalValueForHorizontalIndex(JBLineChartView lineChartView, nuint horizontalIndex, nuint lineIndex);

        // @optional -(void)lineChartView:(JBLineChartView *)lineChartView didSelectLineAtIndex:(NSUInteger)lineIndex horizontalIndex:(NSUInteger)horizontalIndex touchPoint:(CGPoint)touchPoint;
        [Export("lineChartView:didSelectLineAtIndex:horizontalIndex:touchPoint:")]
        void DidSelectLineAtIndex(JBLineChartView lineChartView, nuint lineIndex, nuint horizontalIndex, CGPoint touchPoint);

        // @optional -(void)lineChartView:(JBLineChartView *)lineChartView didSelectLineAtIndex:(NSUInteger)lineIndex horizontalIndex:(NSUInteger)horizontalIndex;
        [Export("lineChartView:didSelectLineAtIndex:horizontalIndex:")]
        void DidSelectLineAtIndex(JBLineChartView lineChartView, nuint lineIndex, nuint horizontalIndex);

        // @optional -(void)didDeselectLineInLineChartView:(JBLineChartView *)lineChartView;
        [Export("didDeselectLineInLineChartView:")]
        void DidDeselectLineInLineChartView(JBLineChartView lineChartView);

        // @optional -(BOOL)lineChartView:(JBLineChartView *)lineChartView shouldIgnoreSelectionAtLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:shouldIgnoreSelectionAtLineIndex:")]
        bool ShouldIgnoreSelectionAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);

        // @optional -(UIColor *)lineChartView:(JBLineChartView *)lineChartView colorForLineAtLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:colorForLineAtLineIndex:")]
        UIColor ColorForLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);

        // @optional -(CAGradientLayer *)lineChartView:(JBLineChartView *)lineChartView gradientForLineAtLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:gradientForLineAtLineIndex:")]
        CAGradientLayer GradientForLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);

        // @optional -(UIColor *)lineChartView:(JBLineChartView *)lineChartView fillColorForLineAtLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:fillColorForLineAtLineIndex:")]
        UIColor FillColorForLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);

        // @optional -(CAGradientLayer *)lineChartView:(JBLineChartView *)lineChartView fillGradientForLineAtLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:fillGradientForLineAtLineIndex:")]
        CAGradientLayer FillGradientForLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);

        // @optional -(UIColor *)lineChartView:(JBLineChartView *)lineChartView colorForDotAtHorizontalIndex:(NSUInteger)horizontalIndex atLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:colorForDotAtHorizontalIndex:atLineIndex:")]
        UIColor ColorForDotAtHorizontalIndex(JBLineChartView lineChartView, nuint horizontalIndex, nuint lineIndex);

        // @optional -(CGFloat)lineChartView:(JBLineChartView *)lineChartView widthForLineAtLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:widthForLineAtLineIndex:")]
        nfloat WidthForLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);

        // @optional -(CGFloat)lineChartView:(JBLineChartView *)lineChartView dotRadiusForDotAtHorizontalIndex:(NSUInteger)horizontalIndex atLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:dotRadiusForDotAtHorizontalIndex:atLineIndex:")]
        nfloat DotRadiusForDotAtHorizontalIndex(JBLineChartView lineChartView, nuint horizontalIndex, nuint lineIndex);

        // @optional -(CGFloat)verticalSelectionWidthForLineChartView:(JBLineChartView *)lineChartView;
        [Export("verticalSelectionWidthForLineChartView:")]
        nfloat VerticalSelectionWidthForLineChartView(JBLineChartView lineChartView);

        // @optional -(UIColor *)lineChartView:(JBLineChartView *)lineChartView verticalSelectionColorForLineAtLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:verticalSelectionColorForLineAtLineIndex:")]
        UIColor VerticalSelectionColorForLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);

        // @optional -(UIColor *)lineChartView:(JBLineChartView *)lineChartView selectionColorForLineAtLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:selectionColorForLineAtLineIndex:")]
        UIColor SelectionColorForLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);

        // @optional -(CAGradientLayer *)lineChartView:(JBLineChartView *)lineChartView selectionGradientForLineAtLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:selectionGradientForLineAtLineIndex:")]
        CAGradientLayer SelectionGradientForLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);

        // @optional -(UIColor *)lineChartView:(JBLineChartView *)lineChartView selectionFillColorForLineAtLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:selectionFillColorForLineAtLineIndex:")]
        UIColor SelectionFillColorForLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);

        // @optional -(CAGradientLayer *)lineChartView:(JBLineChartView *)lineChartView selectionFillGradientForLineAtLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:selectionFillGradientForLineAtLineIndex:")]
        CAGradientLayer SelectionFillGradientForLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);

        // @optional -(UIColor *)lineChartView:(JBLineChartView *)lineChartView selectionColorForDotAtHorizontalIndex:(NSUInteger)horizontalIndex atLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:selectionColorForDotAtHorizontalIndex:atLineIndex:")]
        UIColor SelectionColorForDotAtHorizontalIndex(JBLineChartView lineChartView, nuint horizontalIndex, nuint lineIndex);

        // @optional -(JBLineChartViewLineStyle)lineChartView:(JBLineChartView *)lineChartView lineStyleForLineAtLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:lineStyleForLineAtLineIndex:")]
        JBLineChartViewLineStyle LineStyleForLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);

        // @optional -(JBLineChartViewColorStyle)lineChartView:(JBLineChartView *)lineChartView colorStyleForLineAtLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:colorStyleForLineAtLineIndex:")]
        JBLineChartViewColorStyle ColorStyleForLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);

        // @optional -(JBLineChartViewColorStyle)lineChartView:(JBLineChartView *)lineChartView fillColorStyleForLineAtLineIndex:(NSUInteger)lineIndex;
        [Export("lineChartView:fillColorStyleForLineAtLineIndex:")]
        JBLineChartViewColorStyle FillColorStyleForLineAtLineIndex(JBLineChartView lineChartView, nuint lineIndex);
    }

    // @interface JBLineChartView : JBChartView
    [BaseType(typeof(JBChartView))]
    interface JBLineChartView
    {
        // @property (nonatomic, weak) id<JBLineChartViewDataSource> _Nullable dataSource;
        [NullAllowed, Export("dataSource", ArgumentSemantic.Weak)]
        JBLineChartViewDataSource DataSource { get; set; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        JBLineChartViewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<JBLineChartViewDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(void)reloadDataAnimated:(BOOL)animated;
        [Export("reloadDataAnimated:")]
        void ReloadDataAnimated(bool animated);

        // @property (readonly, nonatomic) BOOL reloading;
        [Export("reloading")]
        bool Reloading { get; }

        // @property (assign, nonatomic) BOOL showsVerticalSelection;
        [Export("showsVerticalSelection")]
        bool ShowsVerticalSelection { get; set; }

        // @property (assign, nonatomic) BOOL showsLineSelection;
        [Export("showsLineSelection")]
        bool ShowsLineSelection { get; set; }

        // -(UIView *)dotViewAtHorizontalIndex:(NSUInteger)horizontalIndex atLineIndex:(NSUInteger)lineIndex;
        [Export("dotViewAtHorizontalIndex:atLineIndex:")]
        UIView DotViewAtHorizontalIndex(nuint horizontalIndex, nuint lineIndex);
    }

    // @interface JBLineChartLine : NSObject
    [BaseType(typeof(NSObject))]
    interface JBLineChartLine
    {
        // @property (nonatomic, strong) NSArray * lineChartPoints;
        [Export("lineChartPoints", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] LineChartPoints { get; set; }

        // @property (assign, nonatomic) BOOL smoothedLine;
        [Export("smoothedLine")]
        bool SmoothedLine { get; set; }

        // @property (assign, nonatomic) JBLineChartViewLineStyle lineStyle;
        [Export("lineStyle", ArgumentSemantic.Assign)]
        JBLineChartViewLineStyle LineStyle { get; set; }

        // @property (assign, nonatomic) JBLineChartViewColorStyle colorStyle;
        [Export("colorStyle", ArgumentSemantic.Assign)]
        JBLineChartViewColorStyle ColorStyle { get; set; }

        // @property (assign, nonatomic) JBLineChartViewColorStyle fillColorStyle;
        [Export("fillColorStyle", ArgumentSemantic.Assign)]
        JBLineChartViewColorStyle FillColorStyle { get; set; }
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    //partial interface Constants
    //{
    //    // extern const NSInteger kJBLineChartLinesViewUnselectedLineIndex;
    //    [Field("kJBLineChartLinesViewUnselectedLineIndex", "__Internal")]
    //    nint kJBLineChartLinesViewUnselectedLineIndex { get; }
    //}

    // @interface JBLineChartLinesView : UIView
    [BaseType(typeof(UIView))]
    interface JBLineChartLinesView
    {
        // @property (assign, nonatomic) id<JBLineChartLinesViewDataSource> dataSource;
        [Export("dataSource", ArgumentSemantic.Assign)]
        JBLineChartLinesViewDataSource DataSource { get; set; }

        // @property (assign, nonatomic) NSInteger selectedLineIndex;
        [Export("selectedLineIndex")]
        nint SelectedLineIndex { get; set; }

        // -(void)reloadDataAnimated:(BOOL)animated callback:(void (^)())callback;
        [Export("reloadDataAnimated:callback:")]
        void ReloadDataAnimated(bool animated, Action callback);

        // -(void)reloadDataAnimated:(BOOL)animated;
        [Export("reloadDataAnimated:")]
        void ReloadDataAnimated(bool animated);

        // -(void)reloadData;
        [Export("reloadData")]
        void ReloadData();

        // -(void)setSelectedLineIndex:(NSInteger)selectedLineIndex animated:(BOOL)animated;
        [Export("setSelectedLineIndex:animated:")]
        void SetSelectedLineIndex(nint selectedLineIndex, bool animated);

        // -(void)fireCallback:(void (^)())callback;
        [Export("fireCallback:")]
        void FireCallback(Action callback);
    }

    // @protocol JBLineChartLinesViewDataSource <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface JBLineChartLinesViewDataSource
    {
        // @required -(NSArray *)lineChartLinesForLineChartLinesView:(JBLineChartLinesView *)lineChartLinesView;
        [Abstract]
        [Export("lineChartLinesForLineChartLinesView:")]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] LineChartLinesForLineChartLinesView(JBLineChartLinesView lineChartLinesView);

        // @required -(CGFloat)lineChartLinesView:(JBLineChartLinesView *)lineChartLinesView dimmedSelectionOpacityAtLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartLinesView:dimmedSelectionOpacityAtLineIndex:")]
        nfloat DimmedSelectionOpacityAtLineIndex(JBLineChartLinesView lineChartLinesView, nuint lineIndex);

        // @required -(UIColor *)lineChartLinesView:(JBLineChartLinesView *)lineChartLinesView colorForLineAtLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartLinesView:colorForLineAtLineIndex:")]
        UIColor ColorForLineAtLineIndex(JBLineChartLinesView lineChartLinesView, nuint lineIndex);

        // @required -(CAGradientLayer *)lineChartLinesView:(JBLineChartLinesView *)lineChartLinesView gradientForLineAtLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartLinesView:gradientForLineAtLineIndex:")]
        CAGradientLayer GradientForLineAtLineIndex(JBLineChartLinesView lineChartLinesView, nuint lineIndex);

        // @required -(UIColor *)lineChartLinesView:(JBLineChartLinesView *)lineChartLinesView fillColorForLineAtLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartLinesView:fillColorForLineAtLineIndex:")]
        UIColor FillColorForLineAtLineIndex(JBLineChartLinesView lineChartLinesView, nuint lineIndex);

        // @required -(CAGradientLayer *)lineChartLinesView:(JBLineChartLinesView *)lineChartLinesView fillGradientForLineAtLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartLinesView:fillGradientForLineAtLineIndex:")]
        CAGradientLayer FillGradientForLineAtLineIndex(JBLineChartLinesView lineChartLinesView, nuint lineIndex);

        // @required -(CGFloat)lineChartLinesView:(JBLineChartLinesView *)lineChartLinesView widthForLineAtLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartLinesView:widthForLineAtLineIndex:")]
        nfloat WidthForLineAtLineIndex(JBLineChartLinesView lineChartLinesView, nuint lineIndex);

        // @required -(UIColor *)lineChartLinesView:(JBLineChartLinesView *)lineChartLinesView selectionColorForLineAtLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartLinesView:selectionColorForLineAtLineIndex:")]
        UIColor SelectionColorForLineAtLineIndex(JBLineChartLinesView lineChartLinesView, nuint lineIndex);

        // @required -(CAGradientLayer *)lineChartLinesView:(JBLineChartLinesView *)lineChartLinesView selectionGradientForLineAtLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartLinesView:selectionGradientForLineAtLineIndex:")]
        CAGradientLayer SelectionGradientForLineAtLineIndex(JBLineChartLinesView lineChartLinesView, nuint lineIndex);

        // @required -(UIColor *)lineChartLinesView:(JBLineChartLinesView *)lineChartLinesView selectionFillColorForLineAtLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartLinesView:selectionFillColorForLineAtLineIndex:")]
        UIColor SelectionFillColorForLineAtLineIndex(JBLineChartLinesView lineChartLinesView, nuint lineIndex);

        // @required -(CAGradientLayer *)lineChartLinesView:(JBLineChartLinesView *)lineChartLinesView selectionFillGradientForLineAtLineIndex:(NSUInteger)lineIndex;
        [Abstract]
        [Export("lineChartLinesView:selectionFillGradientForLineAtLineIndex:")]
        CAGradientLayer SelectionFillGradientForLineAtLineIndex(JBLineChartLinesView lineChartLinesView, nuint lineIndex);
    }

    // @interface JBLineChartPoint : NSObject
    [BaseType(typeof(NSObject))]
    interface JBLineChartPoint
    {
        // @property (assign, nonatomic) CGPoint position;
        [Export("position", ArgumentSemantic.Assign)]
        CGPoint Position { get; set; }

        // @property (assign, nonatomic) BOOL hidden;
        [Export("hidden")]
        bool Hidden { get; set; }
    }

    // @interface JBShapeLineLayer : CAShapeLayer
    [Protocol, BaseType(typeof(CAShapeLayer))]
    interface JBShapeLineLayer
    {
        // -(instancetype)initWithTag:(NSUInteger)tag filled:(BOOL)filled smoothedLine:(BOOL)smoothedLine lineStyle:(JBLineChartViewLineStyle)lineStyle currentPath:(UIBezierPath *)currentPath;
        [Export("initWithTag:filled:smoothedLine:lineStyle:currentPath:")]
        IntPtr Constructor(nuint tag, bool filled, bool smoothedLine, JBLineChartViewLineStyle lineStyle, UIBezierPath currentPath);

        // @property (readonly, nonatomic) NSUInteger tag;
        [Export("tag")]
        nuint Tag { get; }

        // @property (readonly, nonatomic) BOOL filled;
        [Export("filled")]
        bool Filled { get; }

        // @property (nonatomic, strong) UIBezierPath * currentPath;
        [Export("currentPath", ArgumentSemantic.Strong)]
        UIBezierPath CurrentPath { get; set; }
    }

    // @interface JBStack (NSMutableArray)
    [Category]
    [BaseType(typeof(NSMutableArray))]
    interface NSMutableArray_JBStack
    {
        // -(void)jb_push:(id)object;
        [Export("jb_push:")]
        void Jb_push(NSObject @object);

        // -(id)jb_pop;
        [Export("jb_pop")]
        NSObject Jb_pop(NSObject @object);
    }
}




