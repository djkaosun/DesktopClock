using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClock.Library
{
    /// <summary>
    /// WinuserEvent の種類を示す列挙体。
    /// <a href="https://docs.microsoft.com/en-us/windows/win32/winauto/event-constants">→参考リンク</a>
    /// </summary>
    public enum WinuserEvent : uint
    {
        /// <summary>
        /// 
        /// </summary>
        AIA_Start = 0xA000,

        /// <summary>
        /// 
        /// </summary>
        AIA_End = 0xAFFF,

        /// <summary>
        /// 
        /// </summary>
        Min = 0x00000001,

        /// <summary>
        /// 
        /// </summary>
        Max = 0x7FFFFFFF,

        /// <summary>
        /// 
        /// </summary>
        OEMDefined_Start = 0x0101,

        /// <summary>
        /// 
        /// </summary>
        OEMDefined_End = 0x01FF,

        /// <summary>
        /// 
        /// </summary>
        UIAEventID_Start = 0x4E00,

        /// <summary>
        /// 
        /// </summary>
        UIAEventID_End = 0x4EFF,

        /// <summary>
        /// 
        /// </summary>
        UIAPropID_Start = 0x7500,

        /// <summary>
        /// 
        /// </summary>
        UIAPropID_End = 0x75FF,

        /// <summary>
        /// 
        /// </summary>
        ObjectAcceleratorChange = 0x8012,

        /// <summary>
        /// 
        /// </summary>
        ObjectCloaked = 0x8017,

        /// <summary>
        /// 
        /// </summary>
        ObjectContentScrolled = 0x8015,

        /// <summary>
        /// 
        /// </summary>
        ObjectCreate = 0x8000,

        /// <summary>
        /// 
        /// </summary>
        ObjectDefactionChange = 0x8011,

        /// <summary>
        /// 
        /// </summary>
        ObjectDescriptionChange = 0x800D,

        /// <summary>
        /// 
        /// </summary>
        ObjectDestroy = 0x8001,

        /// <summary>
        /// 
        /// </summary>
        ObjectDragStart = 0x8021,

        /// <summary>
        /// 
        /// </summary>
        ObjectDragCancel = 0x8022,

        /// <summary>
        /// 
        /// </summary>
        ObjectDragComplete = 0x8023,

        /// <summary>
        /// 
        /// </summary>
        ObjectDragEnter = 0x8024,

        /// <summary>
        /// 
        /// </summary>
        ObjectDragLeave = 0x8025,

        /// <summary>
        /// 
        /// </summary>
        ObjectDragDropped = 0x8026,

        /// <summary>
        /// 
        /// </summary>
        ObjectEnd = 0x80FF,

        /// <summary>
        /// 
        /// </summary>
        ObjectFocus = 0x8005,

        /// <summary>
        /// 
        /// </summary>
        ObjectHelpChange = 0x8010,

        /// <summary>
        /// 
        /// </summary>
        ObjectHide = 0x8003,

        /// <summary>
        /// 
        /// </summary>
        ObjectHostedObjectsInvalidated = 0x8020,

        /// <summary>
        /// 
        /// </summary>
        ObjectIMEHide = 0x8028,

        /// <summary>
        /// 
        /// </summary>
        ObjectIMEShow = 0x8027,

        /// <summary>
        /// 
        /// </summary>
        ObjectIMEChange = 0x8029,

        /// <summary>
        /// 
        /// </summary>
        ObjectInvoked = 0x8013,

        /// <summary>
        /// 
        /// </summary>
        ObjectLiveRegionChanged = 0x8019,

        /// <summary>
        /// 
        /// </summary>
        ObjectLocationChange = 0x800B,

        /// <summary>
        /// 
        /// </summary>
        ObjectNameChange = 0x800C,

        /// <summary>
        /// 
        /// </summary>
        ObjectParentChange = 0x800F,

        /// <summary>
        /// 
        /// </summary>
        ObjectReorder = 0x8004,

        /// <summary>
        /// 
        /// </summary>
        ObjectSelection = 0x8006,

        /// <summary>
        /// 
        /// </summary>
        ObjectSelectionAdd = 0x8007,

        /// <summary>
        /// 
        /// </summary>
        ObjectSelectionRemove = 0x8008,

        /// <summary>
        /// 
        /// </summary>
        ObjectSelectionWithin = 0x8009,

        /// <summary>
        /// 
        /// </summary>
        ObjectShow = 0x8002,

        /// <summary>
        /// 
        /// </summary>
        ObjectStateChange = 0x800A,

        /// <summary>
        /// 
        /// </summary>
        ObjectTextEditConversionTargetChanged = 0x8030,

        /// <summary>
        /// 
        /// </summary>
        ObjectTextSelectionChanged = 0x8014,

        /// <summary>
        /// 
        /// </summary>
        ObjectUncloaked = 0x8018,

        /// <summary>
        /// 
        /// </summary>
        ObjectValueChange = 0x800E,

        /// <summary>
        /// 
        /// </summary>
        SystemAlert = 0x0002,

        /// <summary>
        /// 
        /// </summary>
        SystemArrengmentPreview = 0x8016,

        /// <summary>
        /// 
        /// </summary>
        SystemCaptureEnd = 0x0009,

        /// <summary>
        /// 
        /// </summary>
        SystemCaptureStart = 0x0008,

        /// <summary>
        /// 
        /// </summary>
        SystemContextHelpEnd = 0x000D,

        /// <summary>
        /// 
        /// </summary>
        SystemContextHeptStart = 0x000C,

        /// <summary>
        /// 
        /// </summary>
        SystemDesktopSwitch = 0x0020,

        /// <summary>
        /// 
        /// </summary>
        SystemDialogEnd = 0x0011,

        /// <summary>
        /// 
        /// </summary>
        SystemDialogStart = 0x0010,

        /// <summary>
        /// 
        /// </summary>
        SystemDragDropEnd = 0x000F,

        /// <summary>
        /// 
        /// </summary>
        SystemDragDropStart = 0x000E,

        /// <summary>
        /// 
        /// </summary>
        SystemEnd = 0x00FF,

        /// <summary>
        /// 
        /// </summary>
        SystemForeground = 0x0003,

        /// <summary>
        /// 
        /// </summary>
        SystemMenuPopupEnd = 0x0007,

        /// <summary>
        /// 
        /// </summary>
        SystemMenuPopupStart = 0x0006,

        /// <summary>
        /// 
        /// </summary>
        SystemMenuEnd = 0x0005,

        /// <summary>
        /// 
        /// </summary>
        SystemMenuStart = 0x0004,

        /// <summary>
        /// 
        /// </summary>
        SystemMinimizeEnd = 0x0017,

        /// <summary>
        /// 
        /// </summary>
        SystemMinimizeStart = 0x0016,

        /// <summary>
        /// 
        /// </summary>
        SystemMoveSizeEnd = 0x000B,

        /// <summary>
        /// 
        /// </summary>
        SystemMoveSizeStart = 0x000A,

        /// <summary>
        /// 
        /// </summary>
        SystemScrollingEnd = 0x0013,

        /// <summary>
        /// 
        /// </summary>
        SystemScrollingStart = 0x0012,

        /// <summary>
        /// 
        /// </summary>
        SystemSound = 0x0001,

        /// <summary>
        /// 
        /// </summary>
        SystemSwitchEnd = 0x0015,

        /// <summary>
        /// 
        /// </summary>
        SystemSwitchStart = 0x0014
    }
}
