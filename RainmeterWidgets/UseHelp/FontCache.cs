// 本代码由 AI 工具生成。

using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace UseHelp
{
    /// <summary>
    /// 字体缓存管理器（单例模式），支持缓存多个不同参数的字体实例
    /// 当指定字体存在时使用指定字体，否则回退为系统默认字体（微软雅黑）
    /// 实现IDisposable接口，适用于.NET 8及以上版本
    /// </summary>
    public sealed class FontCache : IDisposable
    {
        private static readonly Lazy<FontCache> _instance = new(() => new FontCache());
        private readonly ConcurrentDictionary<string, Font> _fontDictionary;
        private readonly PrivateFontCollection _privateFontCollection;
        private bool _disposed;

        /// <summary>
        /// 获取全局唯一的FontCache实例
        /// </summary>
        public static FontCache Instance => _instance.Value;

        /// <summary>
        /// 获取当前缓存的字体数量
        /// </summary>
        public int CachedFontCount => _fontDictionary.Count;

        private FontCache()
        {
            _fontDictionary = new ConcurrentDictionary<string, Font>();
            _privateFontCollection = new PrivateFontCollection();
        }

        /// <summary>
        /// 获取或创建字体（带缓存）
        /// </summary>
        /// <param name="fontName">字体名称</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="style">字体样式</param>
        /// <param name="unit">图形单位</param>
        /// <returns>字体对象</returns>
        public Font GetFont(string fontName, float fontSize, FontStyle style = FontStyle.Regular, GraphicsUnit unit = GraphicsUnit.Point)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fontName, nameof(fontName));

            string cacheKey = GenerateCacheKey(fontName, fontSize, style, unit);

            return _fontDictionary.GetOrAdd(cacheKey, key => CreateFont(fontName, fontSize, style, unit));
        }

        /// <summary>
        /// 获取或创建字体（使用Font对象作为模板）
        /// </summary>
        /// <param name="templateFont">模板字体</param>
        /// <returns>字体对象</returns>
        public Font GetFont(Font templateFont)
        {
            ArgumentNullException.ThrowIfNull(templateFont, nameof(templateFont));

            return GetFont(templateFont.Name, templateFont.Size, templateFont.Style, templateFont.Unit);
        }

        /// <summary>
        /// 尝试获取缓存的字体
        /// </summary>
        /// <param name="fontName">字体名称</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="style">字体样式</param>
        /// <param name="unit">图形单位</param>
        /// <param name="font">输出字体对象</param>
        /// <returns>是否成功获取</returns>
        public bool TryGetFont(string fontName, float fontSize, FontStyle style, GraphicsUnit unit, out Font? font)
        {
            string cacheKey = GenerateCacheKey(fontName, fontSize, style, unit);
            return _fontDictionary.TryGetValue(cacheKey, out font);
        }

        /// <summary>
        /// 检查指定字体是否已缓存
        /// </summary>
        public bool IsFontCached(string fontName, float fontSize, FontStyle style = FontStyle.Regular, GraphicsUnit unit = GraphicsUnit.Point)
        {
            string cacheKey = GenerateCacheKey(fontName, fontSize, style, unit);
            return _fontDictionary.ContainsKey(cacheKey);
        }

        /// <summary>
        /// 从缓存中移除指定字体
        /// </summary>
        /// <returns>是否成功移除</returns>
        public bool RemoveFont(string fontName, float fontSize, FontStyle style = FontStyle.Regular, GraphicsUnit unit = GraphicsUnit.Point)
        {
            string cacheKey = GenerateCacheKey(fontName, fontSize, style, unit);
            if (_fontDictionary.TryRemove(cacheKey, out Font? font))
            {
                font?.Dispose();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 清除所有缓存的字体
        /// </summary>
        public void ClearAll()
        {
            foreach (var font in _fontDictionary.Values)
            {
                font?.Dispose();
            }
            _fontDictionary.Clear();
        }

        /// <summary>
        /// 移除所有匹配指定字体名称的缓存
        /// </summary>
        /// <param name="fontName">字体名称</param>
        /// <returns>移除的数量</returns>
        public int RemoveAllByFontName(string fontName)
        {
            if (string.IsNullOrWhiteSpace(fontName))
                return 0;

            var keysToRemove = _fontDictionary.Keys
                .Where(key => key.StartsWith($"{fontName}_", StringComparison.OrdinalIgnoreCase))
                .ToList();

            int removedCount = 0;
            foreach (var key in keysToRemove)
            {
                if (_fontDictionary.TryRemove(key, out Font? font))
                {
                    font?.Dispose();
                    removedCount++;
                }
            }
            return removedCount;
        }

        /// <summary>
        /// 生成缓存键
        /// </summary>
        private static string GenerateCacheKey(string fontName, float fontSize, FontStyle style, GraphicsUnit unit)
        {
            return $"{fontName}_{fontSize}_{style}_{unit}".ToLowerInvariant();
        }

        /// <summary>
        /// 创建字体（带回退机制）
        /// </summary>
        private Font CreateFont(string fontName, float fontSize, FontStyle style, GraphicsUnit unit)
        {
            // 尝试创建指定字体
            if (IsFontInstalled(fontName))
            {
                try
                {
                    return new Font(fontName, fontSize, style, unit);
                }
                catch
                {
                    // 创建失败，使用回退字体
                    return CreateFallbackFont(fontSize, style, unit);
                }
            }

            // 字体未安装，使用回退字体
            return CreateFallbackFont(fontSize, style, unit);
        }

        /// <summary>
        /// 创建回退字体（微软雅黑）
        /// </summary>
        private Font CreateFallbackFont(float fontSize, FontStyle style, GraphicsUnit unit)
        {
            const string fallbackFontName = "微软雅黑";

            // 检查微软雅黑是否可用
            if (IsFontInstalled(fallbackFontName))
            {
                try
                {
                    return new Font(fallbackFontName, fontSize, style, unit);
                }
                catch
                {
                    // 如果微软雅黑创建失败，使用系统默认字体
                    return new Font(SystemFonts.DefaultFont, FontStyle.Regular);
                }
            }

            // 如果微软雅黑未安装，使用系统默认字体
            return new Font(SystemFonts.DefaultFont, FontStyle.Regular);
        }

        /// <summary>
        /// 检查字体是否已安装
        /// </summary>
        private static bool IsFontInstalled(string fontName)
        {
            using (var testFont = new Font(fontName, 8))
            {
                // 比较实际字体名称与请求的字体名称
                return testFont.Name.Equals(fontName, StringComparison.OrdinalIgnoreCase);
            }
        }

        /// <summary>
        /// 释放所有资源
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
                return;

            ClearAll();
            _privateFontCollection?.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }

    /// <summary>
    /// 便捷的字体包装类，用于自动释放字体资源
    /// </summary>
    public sealed class CachedFontWrapper : IDisposable
    {
        private readonly FontCache _cache;
        private readonly string _fontName;
        private readonly float _fontSize;
        private readonly FontStyle _style;
        private readonly GraphicsUnit _unit;
        private bool _disposed;

        public Font Font { get; private set; }

        public CachedFontWrapper(string fontName, float fontSize, FontStyle style = FontStyle.Regular, GraphicsUnit unit = GraphicsUnit.Point)
        {
            _cache = FontCache.Instance;
            _fontName = fontName;
            _fontSize = fontSize;
            _style = style;
            _unit = unit;
            Font = _cache.GetFont(fontName, fontSize, style, unit);
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            // 注意：这里不释放Font对象，因为它由缓存管理
            Font = null!;
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}