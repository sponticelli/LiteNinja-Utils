using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace LiteNinja.Utils.Extensions
{
    public static class RectTransformExtensions
    {
        public static void SetExtended(this RectTransform self)
        {
            self.anchorMin = Vector2.zero;
            self.anchorMax = Vector2.one;
            self.offsetMax = Vector2.zero;
            self.offsetMin = Vector2.zero;
        }
        
        
        public static void SetAnchoredPosition(this RectTransform self, float x, float y)
        {
            self.anchoredPosition = new Vector2(x, y);
        }

        public static void SetAnchoredPositionX(this RectTransform self, float x)
        {
            self.anchoredPosition = new Vector2(x, self.anchoredPosition.y);
        }

        public static void SetAnchoredPositionY(this RectTransform self, float y)
        {
            self.anchoredPosition = new Vector2(self.anchoredPosition.x, y);
        }

        public static void SetSizeDelta(this RectTransform self, float x, float y)
        {
            self.sizeDelta = new Vector2(x, y);
        }

        public static void SetSizeDeltaX(this RectTransform self, float x)
        {
            self.sizeDelta = new Vector2(x, self.sizeDelta.y);
        }

        public static void SetSizeDeltaY(this RectTransform self, float y)
        {
            self.sizeDelta = new Vector2(self.sizeDelta.x, y);
        }

        #region Move Sides

        public static void SetLeft(this RectTransform self, float left)
        {
            self.offsetMin = new Vector2(left, self.offsetMin.y);
        }

        public static void SetRight(this RectTransform self, float right)
        {
            self.offsetMax = new Vector2(-right, self.offsetMax.y);
        }

        public static void SetTop(this RectTransform self, float top)
        {
            self.offsetMax = new Vector2(self.offsetMax.x, -top);
        }

        public static void SetBottom(this RectTransform self, float bottom)
        {
            self.offsetMin = new Vector2(self.offsetMin.x, bottom);
        }

        #endregion

        #region Move Corners

        public static void SetTopLeft(this RectTransform self, float top, float left)
        {
            self.offsetMin = new Vector2(left, self.offsetMin.y);
            self.offsetMax = new Vector2(self.offsetMax.x, top);
        }

        public static void SetTopRight(this RectTransform self, float top, float right)
        {
            self.offsetMax = new Vector2(right, top);
        }

        public static void SetBottomLeft(this RectTransform self, float bottom, float left)
        {
            self.offsetMin = new Vector2(left, bottom);
        }

        public static void SetBottomRight(this RectTransform self, float bottom, float right)
        {
            self.offsetMin = new Vector2(self.offsetMin.x, bottom);
            self.offsetMax = new Vector2(right, self.offsetMax.y);
        }

        #endregion

        #region Anchor to sides

        public static void SetAnchorTop(this RectTransform self, bool positionAtAnchor = false)
        {
            self.anchorMin = new Vector2(0.5f, 1f);
            self.anchorMax = new Vector2(0.5f, 1f);
            if (positionAtAnchor)
            {
                self.anchoredPosition = Vector2.zero;
            }
        }

        public static void SetAnchorBottom(this RectTransform self, bool positionAtAnchor = false)
        {
            self.anchorMin = new Vector2(0.5f, 0f);
            self.anchorMax = new Vector2(0.5f, 0f);
            if (positionAtAnchor)
            {
                self.anchoredPosition = Vector2.zero;
            }
        }

        public static void SetAnchorLeft(this RectTransform self, bool positionAtAnchor = false)
        {
            self.anchorMin = new Vector2(0f, 0.5f);
            self.anchorMax = new Vector2(0f, 0.5f);
            if (positionAtAnchor)
            {
                self.anchoredPosition = Vector2.zero;
            }
        }

        public static void SetAnchorRight(this RectTransform self, bool positionAtAnchor = false)
        {
            self.anchorMin = new Vector2(1f, 0.5f);
            self.anchorMax = new Vector2(1f, 0.5f);
            if (positionAtAnchor)
            {
                self.anchoredPosition = Vector2.zero;
            }
        }

        #endregion

        #region Anchor to corners

        public static void SetAnchorTopLeft(this RectTransform self, bool positionAtAnchor = false)
        {
            self.anchorMin = new Vector2(0f, 1f);
            self.anchorMax = new Vector2(0f, 1f);
            if (positionAtAnchor)
            {
                self.anchoredPosition = Vector2.zero;
            }
        }

        public static void SetAnchorTopRight(this RectTransform self, bool positionAtAnchor = false)
        {
            self.anchorMin = new Vector2(1f, 1f);
            self.anchorMax = new Vector2(1f, 1f);
            if (positionAtAnchor)
            {
                self.anchoredPosition = Vector2.zero;
            }
        }

        public static void SetAnchorBottomLeft(this RectTransform self, bool positionAtAnchor = false)
        {
            self.anchorMin = new Vector2(0f, 0f);
            self.anchorMax = new Vector2(0f, 0f);
            if (positionAtAnchor)
            {
                self.anchoredPosition = Vector2.zero;
            }
        }

        public static void SetAnchorBottomRight(this RectTransform self, bool positionAtAnchor = false)
        {
            self.anchorMin = new Vector2(1f, 0f);
            self.anchorMax = new Vector2(1f, 0f);
            if (positionAtAnchor)
            {
                self.anchoredPosition = Vector2.zero;
            }
        }

        #endregion

        #region Stretch Across Vertical & Horizontal

        public static void SetAnchorAndStretchVertical(this RectTransform self, float width = 1f)
        {
            self.offsetMin = new Vector2(0f, self.offsetMax.y);
            self.offsetMax = new Vector2(width, self.offsetMax.y);
            self.anchorMin = new Vector2(0.5f, 0);
            self.anchorMax = new Vector2(0.5f, 1f);
            self.anchoredPosition = Vector2.zero;
        }

        public static void SetAnchorAndStretchHorizontal(this RectTransform self, float height = 1f)
        {
            self.offsetMin = new Vector2(self.offsetMax.x, -height);
            self.offsetMax = new Vector2(self.offsetMax.x, 0f);
            self.anchorMin = new Vector2(0f, 0.5f);
            self.anchorMax = new Vector2(1f, 0.5f);
            self.anchoredPosition = Vector2.zero;
        }

        #endregion

        #region Stretch Sides

        public static void SetAnchorAndStretchAcrossTop(this RectTransform self, float height = 1f)
        {
            self.offsetMin = new Vector2(self.offsetMax.x, -height);
            self.offsetMax = new Vector2(self.offsetMax.x, 0f);
            self.anchorMin = new Vector2(0f, 1);
            self.anchorMax = new Vector2(1f, 1f);
            self.anchoredPosition = Vector2.zero;
        }

        public static void SetAnchorAndStretchAcrossBottom(this RectTransform self, float height = 1f)
        {
            self.offsetMin = new Vector2(self.offsetMax.x, 0f);
            self.offsetMax = new Vector2(self.offsetMax.x, height);
            self.anchorMin = new Vector2(0f, 0);
            self.anchorMax = new Vector2(1f, 0f);
            self.anchoredPosition = Vector2.zero;
        }

        public static void SetAnchorAndStretchAcrossLeft(this RectTransform self, float width = 1f)
        {
            self.offsetMin = new Vector2(-width, self.offsetMax.y);
            self.offsetMax = new Vector2(0f, self.offsetMax.y);
            self.anchorMin = new Vector2(0f, 0);
            self.anchorMax = new Vector2(0f, 1f);
            self.anchoredPosition = Vector2.zero;
        }

        public static void SetAnchorAndStretchAcrossRight(this RectTransform self, float width = 1f)
        {
            self.offsetMin = new Vector2(0f, self.offsetMax.y);
            self.offsetMax = new Vector2(width, self.offsetMax.y);
            self.anchorMin = new Vector2(1f, 0);
            self.anchorMax = new Vector2(1f, 1f);
            self.anchoredPosition = Vector2.zero;
        }

        #endregion


        public static bool SetAnchor(this RectTransform self, Anchors align)
        {
            if (_anchorPresetsByType.ContainsKey(align) != true) return false;
            var v4 = _anchorPresetsByType[align];

            self.anchorMin = new Vector2(v4.minX, v4.minY);
            self.anchorMax = new Vector2(v4.maxX, v4.maxY);
            return true;
        }

        public static Anchors GetAnchor(this RectTransform self)
        {
            if (_anchorPresetsMap == null)
            {
                _anchorPresetsMap = new Dictionary<AnchorPreset, Anchors>();
                foreach (var (key, value) in _anchorPresetsByType
                    .Where(each => _anchorPresetsMap.ContainsKey(each.Value) == false))
                {
                    _anchorPresetsMap.Add(value, key);
                }
            }

            var anchorMin = self.anchorMin;
            var anchorMax = self.anchorMax;
            var anchorPreset = new AnchorPreset(anchorMin.x, anchorMin.y, anchorMax.x, anchorMax.y);
            return _anchorPresetsMap.ContainsKey(anchorPreset)
                ? _anchorPresetsMap[anchorPreset]
                : Anchors.None;
        }

        public static bool SetPivot(this RectTransform self, Pivots preset)
        {
            if (_pivotPresetsToVector2Map.ContainsKey(preset) != true) return false;
            var v2 = _pivotPresetsToVector2Map[preset];

            self.pivot = new Vector2(v2.x, v2.y);
            return true;
        }

        public static Pivots GetPivot(this RectTransform self)
        {
            if (_vector2ToPivotPresets == null)
            {
                _vector2ToPivotPresets = new Dictionary<Vector2, Pivots>();
                foreach (var (key, value) in _pivotPresetsToVector2Map
                    .Where(each => _vector2ToPivotPresets.ContainsKey(each.Value) == false))
                {
                    _vector2ToPivotPresets.Add(value, key);
                }
            }

            var pivot = self.pivot;
            var v2 = new Vector2(pivot.x, pivot.y);
            return _vector2ToPivotPresets.ContainsKey(v2) ? _vector2ToPivotPresets[v2] : Pivots.None;
        }

        public static void SetPosition(this RectTransform self, float offsetX, float offsetY)
        {
            var anchor = GetAnchor(self);
            switch (anchor)
            {
                case Anchors.TopLeft:
                case Anchors.TopCenter:
                case Anchors.TopRight:
                case Anchors.MiddleLeft:
                case Anchors.MiddleCenter:
                case Anchors.MiddleRight:
                case Anchors.BottomLeft:
                case Anchors.BottomCenter:
                case Anchors.BottomRight:
                    self.anchoredPosition = new Vector3(offsetX, offsetY, 0f);
                    break;
                case Anchors.HorizontalStretchTop:
                case Anchors.HorizontalStretchMiddle:
                case Anchors.HorizontalStretchBottom:
                    self.anchoredPosition = new Vector3(offsetX, -offsetY, 0f);
                    break;
                case Anchors.VerticalStretchLeft:
                case Anchors.VerticalStretchCenter:
                case Anchors.VerticalStretchRight:
                    self.anchoredPosition = new Vector3(offsetX, offsetY, 0f);
                    break;
                case Anchors.StretchAll:
                    self.anchoredPosition = new Vector3(offsetX, -offsetY, 0f);
                    break;
                case Anchors.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static Vector2 GetPosition(this RectTransform self)
        {
            var anchor = GetAnchor(self);
            switch (anchor)
            {
                case Anchors.TopLeft:
                case Anchors.TopCenter:
                case Anchors.TopRight:
                case Anchors.MiddleLeft:
                case Anchors.MiddleCenter:
                case Anchors.MiddleRight:
                case Anchors.BottomLeft:
                case Anchors.BottomCenter:
                case Anchors.BottomRight:
                    break;
                case Anchors.HorizontalStretchTop:
                case Anchors.HorizontalStretchMiddle:
                case Anchors.HorizontalStretchBottom:
                    var anchoredPosition = self.anchoredPosition;
                    return new Vector2(anchoredPosition.x, -anchoredPosition.y);
                case Anchors.VerticalStretchLeft:
                case Anchors.VerticalStretchCenter:
                case Anchors.VerticalStretchRight:
                    break;
                case Anchors.StretchAll:
                    var position = self.anchoredPosition;
                    return new Vector2(position.x, -position.y);
                case Anchors.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return self.anchoredPosition;
        }

        public static void SetSize(this RectTransform self, float width, float height)
        {
            var anchor = GetAnchor(self);
            switch (anchor)
            {
                case Anchors.TopLeft:
                case Anchors.TopCenter:
                case Anchors.TopRight:
                case Anchors.MiddleLeft:
                case Anchors.MiddleCenter:
                case Anchors.MiddleRight:
                case Anchors.BottomLeft:
                case Anchors.BottomCenter:
                case Anchors.BottomRight:
                    self.sizeDelta = new Vector2(width, height);
                    break;
                case Anchors.HorizontalStretchTop:
                case Anchors.HorizontalStretchMiddle:
                case Anchors.HorizontalStretchBottom:
                {
                    var parent = self.parent.GetComponent<RectTransform>();
                    var size = parent.GetSize();
                    self.sizeDelta = new Vector2(width - size.x, height);
                }
                    break;
                case Anchors.VerticalStretchLeft:
                case Anchors.VerticalStretchCenter:
                case Anchors.VerticalStretchRight:
                {
                    var parent = self.parent.GetComponent<RectTransform>();
                    var size = parent.GetSize();
                    self.sizeDelta = new Vector2(width, height - size.y);
                }
                    break;
                case Anchors.StretchAll:
                {
                    var parent = self.parent.GetComponent<RectTransform>();
                    var size = parent.GetSize();
                    self.sizeDelta = new Vector2(width - size.x, height - size.y);
                }
                    break;
                case Anchors.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static void SetSize(this RectTransform self)
        {
            var parent = self.parent.GetComponent<RectTransform>();
            var size = parent.GetSize();
            self.SetSize(size.x, size.y);
        }

        public static Vector2 GetSize(this RectTransform self)
        {
            var scaler = self.GetComponent<CanvasScaler>();
            if (scaler != null)
            {
                switch (scaler.uiScaleMode)
                {
                    case CanvasScaler.ScaleMode.ScaleWithScreenSize:
                        switch (scaler.screenMatchMode)
                        {
                            case CanvasScaler.ScreenMatchMode.MatchWidthOrHeight:
                            {
                                var width = scaler.referenceResolution.y * Screen.width / Screen.height;
                                width = scaler.referenceResolution.x +
                                        (width - scaler.referenceResolution.x) * scaler.matchWidthOrHeight;
                                var height = width * Screen.height / Screen.width;
                                return new Vector2(Mathf.RoundToInt(width), Mathf.RoundToInt(height));
                            }
                            case CanvasScaler.ScreenMatchMode.Expand: // height fix
                            {
                                var width = scaler.referenceResolution.y * Screen.width / Screen.height;
                                return new Vector2(Mathf.RoundToInt(width),
                                    Mathf.RoundToInt(scaler.referenceResolution.y));
                            }
                            case CanvasScaler.ScreenMatchMode.Shrink: // width fix
                            {
                                var height = scaler.referenceResolution.x * Screen.height / Screen.width;
                                return new Vector2(Mathf.RoundToInt(scaler.referenceResolution.x),
                                    Mathf.RoundToInt(height));
                            }
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    case CanvasScaler.ScaleMode.ConstantPixelSize:
                        break;
                    case CanvasScaler.ScaleMode.ConstantPhysicalSize:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            var align = GetAnchor(self);
            switch (align)
            {
                case Anchors.TopLeft:
                case Anchors.TopCenter:
                case Anchors.TopRight:
                case Anchors.MiddleLeft:
                case Anchors.MiddleCenter:
                case Anchors.MiddleRight:
                case Anchors.BottomLeft:
                case Anchors.BottomCenter:
                case Anchors.BottomRight:
                    return self.sizeDelta;
                case Anchors.HorizontalStretchTop:
                case Anchors.HorizontalStretchMiddle:
                case Anchors.HorizontalStretchBottom:
                {
                    var parent = self.parent.GetComponent<RectTransform>();
                    var size = parent.GetSize();
                    var sizeDelta = self.sizeDelta;
                    return new Vector2(sizeDelta.x, size.y + sizeDelta.y);
                }
                case Anchors.VerticalStretchLeft:
                case Anchors.VerticalStretchCenter:
                case Anchors.VerticalStretchRight:
                {
                    var parent = self.parent.GetComponent<RectTransform>();
                    var size = parent.GetSize();
                    var sizeDelta = self.sizeDelta;
                    return new Vector2(size.x + sizeDelta.x, sizeDelta.y);
                }
                case Anchors.StretchAll:
                {
                    var parent = self.parent.GetComponent<RectTransform>();
                    return (parent.GetSize() + self.sizeDelta);
                }
                case Anchors.None:
                    return Vector2.zero;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #region private maps

        private class AnchorPreset
        {
            public float minX { get; private set; }
            public float maxX { get; private set; }
            public float minY { get; private set; }
            public float maxY { get; private set; }

            public AnchorPreset(float minX, float maxX, float minY, float maxY)
            {
                this.minX = minX;
                this.maxX = maxX;
                this.minY = minY;
                this.maxY = maxY;
            }
        } 
        
        private static readonly Dictionary<Anchors, AnchorPreset> _anchorPresetsByType =
            new()
            {
                { Anchors.TopLeft, new AnchorPreset(0f, 1f, 0f, 1f) },
                { Anchors.TopCenter, new AnchorPreset(0.5f, 1f, 0.5f, 1f) },
                { Anchors.TopRight, new AnchorPreset(1f, 1f, 1f, 1f) },

                { Anchors.MiddleLeft, new AnchorPreset(0f, 0.5f, 0f, 0.5f) },
                { Anchors.MiddleCenter, new AnchorPreset(0.5f, 0.5f, 0.5f, 0.5f) },
                { Anchors.MiddleRight, new AnchorPreset(1f, 0.5f, 1f, 0.5f) },

                { Anchors.BottomLeft, new AnchorPreset(0f, 0f, 0f, 0f) },
                { Anchors.BottomCenter, new AnchorPreset(0.5f, 0f, 0.5f, 0f) },
                { Anchors.BottomRight, new AnchorPreset(1f, 0f, 1f, 0f) },

                { Anchors.HorizontalStretchTop, new AnchorPreset(0f, 1f, 1f, 1f) },
                { Anchors.HorizontalStretchMiddle, new AnchorPreset(0f, 0.5f, 1f, 0.5f) },
                { Anchors.HorizontalStretchBottom, new AnchorPreset(0f, 0f, 1f, 0f) },

                { Anchors.VerticalStretchLeft, new AnchorPreset(0f, 0f, 0f, 1f) },
                { Anchors.VerticalStretchCenter, new AnchorPreset(0.5f, 0f, 0.5f, 1f) },
                { Anchors.VerticalStretchRight, new AnchorPreset(1f, 0f, 1f, 1f) },

                { Anchors.StretchAll, new AnchorPreset(0f, 0f, 1f, 1f) }
            };

        private static Dictionary<AnchorPreset, Anchors> _anchorPresetsMap;

        private static readonly Dictionary<Pivots, Vector2> _pivotPresetsToVector2Map =
            new()
            {
                { Pivots.TopLeft, new Vector2(0f, 1f) },
                { Pivots.TopCenter, new Vector2(0.5f, 1f) },
                { Pivots.TopRight, new Vector2(1f, 1f) },

                { Pivots.MiddleLeft, new Vector2(0f, 0.5f) },
                { Pivots.MiddleCenter, new Vector2(0.5f, 0.5f) },
                { Pivots.MiddleRight, new Vector2(1f, 0.5f) },

                { Pivots.BottomLeft, new Vector2(0f, 0f) },
                { Pivots.BottomCenter, new Vector2(0.5f, 0f) },
                { Pivots.BottomRight, new Vector2(1f, 0f) }
            };

        private static Dictionary<Vector2, Pivots> _vector2ToPivotPresets;

        #endregion
    }
    
    public enum Anchors
    {
        None = 0,

        TopLeft,
        TopCenter,
        TopRight,

        MiddleLeft,
        MiddleCenter,
        MiddleRight,

        BottomLeft,
        BottomCenter,
        BottomRight,

        HorizontalStretchTop,
        HorizontalStretchMiddle,
        HorizontalStretchBottom,

        VerticalStretchLeft,
        VerticalStretchCenter,
        VerticalStretchRight,

        StretchAll
    }

    public enum Pivots
    {
        None = 0,

        TopLeft,
        TopCenter,
        TopRight,

        MiddleLeft,
        MiddleCenter,
        MiddleRight,

        BottomLeft,
        BottomCenter,
        BottomRight
    }
}