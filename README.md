<div align="center">

![EggyUI 宣传图](https://eggyuihub.wordpress.com/wp-content/uploads/2026/04/eggyui-poster.jpg)

# EggyUI

![Last Commit](https://img.shields.io/github/last-commit/QiXiaoLight/EggyUI?label=最近提交)
![Windows Support](https://img.shields.io/badge/Windows-Supported-blue)
[![QQ 群](https://img.shields.io/badge/QQ群-1090050382-blue)](https://qm.qq.com/q/DzX7VXZNMQ)
[![License](https://img.shields.io/badge/代码许可证-GPL%20v3-yellow)](LICENSE.txt)

不修改系统核心文件，延续蛋仔视觉美学。

</div>

## 项目简介

EggyUI 是 EggyUI 生态的主项目，专注于以**不修改系统核心文件**的方式实现蛋仔派对风格的 Windows 桌面美化。本项目由新开发团队于 2026 年 4 月 11 日以 EggyUI-SE 为基础变基而来，原仓库已归档为 [EggyUI-Legacy](https://github.com/SYSTEM-LIGHT/EggyUI-Legacy)。

项目在核心设计上做出了重要调整：所有美化内容均通过主题包、壁纸、音效等安全方式部署，而非替换系统关键文件（如 `imageres.dll.mun`）。

EggyUI 以**独立安装包**的形式在已有 Windows 系统上部署，让用户无需重装系统即可享受蛋仔风格的视觉体验。

## 包含美化组件
| 美化组件 | 系统要求 |
|---------|---------|
| 主题包 | Windows 7 ~ Windows 11 |
| Rainmeter 小组件 | Windows 10 1607 ~ Windows 11 |

> [!TIP]
> EggyUI 的扩展美化组件可从 [EggyUI Hub](https://eggyuihub.wordpress.com/) 下载。建议搭配这些组件使用以获得最佳体验。

## 历史背景

EggyUI 最初由 [BSOD-MEMZ](https://github.com/BSOD-MEMZ) 于 2024 年 7 月发起，曾以独特的视觉美学获得众多用户青睐。然而，原项目存在诸多问题：

- **技术债务**：早期大量使用易语言编写组件，导致性能低下、报毒频发、维护困难。
- **团队治理混乱**：项目缺乏有效的决策机制，关键权限集中在少数成员手中。2025 年 5 月，一名非创始成员单方面宣布“项目组解散”，引发社区混乱。创始人 BSOD-MEMZ 及核心成员均明确反对，但团队士气已遭受不可逆的损伤。
- **开发停滞**：BSOD-MEMZ 后期已放弃项目维护，剩余开发者因内耗和资源不足难以推进。EggyUI-RE 分支虽尝试延续，但陷入技术困境（Python 打包报毒、WebView 兼容性问题、开发者不活跃），至今未能发布稳定版本。

2025 年 10 月 5 日，原项目正式归档。2026 年 4 月 11 日，新开发团队以 EggyUI-SE 为基础对项目进行变基，恢复开发。

## 变基后的 EggyUI 与历史版本的区别

| 维度 | 历史 EggyUI（已归档） | 当前 EggyUI（变基后） |
|------|----------------------|----------------------|
| 技术栈 | 易语言、.NET 8、Python 混合 | .NET 6（统一、稳定） |
| 安装方式 | 系统镜像、无人值守安装 | 独立安装包，可选组件 |
| 系统文件修改 | 替换 `imageres.dll.mun` 等核心文件 | **不修改任何系统文件** |
| 维护状态 | 已停止更新，团队解散 | 新开发团队持续维护 |
| 分发渠道 | 网盘直链 | GitHub Releases + 官网、聚合页导航 |

## 为什么要变基？

在原 EggyUI 的发展历程中，部分早期版本通过替换系统核心文件来实现系统图标等底层美化。这种方式虽然视觉效果显著，但也带来了潜在风险：一旦文件替换不当或版本不匹配，可能导致控制面板异常、系统无法启动等问题。

新团队选择了一条更安全的技术路径：

- **不修改系统核心文件**：所有美化内容通过主题包、壁纸、音效等安全方式部署。
- **降低维护成本**：无需为不同 Windows 版本制作大量兼容性补丁。
- **用户更安心**：安装与卸载不会影响系统底层稳定性。

## 本仓库的内容

本仓库用于存放 EggyUI 相关组件的**源代码**，包括：

- 主题包安装与卸载逻辑
- 鼠标光标等资源的部署脚本
- 配套的 Rainmeter 桌面小组件的辅助程序

独立安装包的下载链接以及使用说明，请参阅项目官网或发布公告。

## 版权声明

- 本项目为粉丝二次创作，非官方出品，禁止用于商业用途。
- 所有视觉素材均来自合规渠道或团队重制，未使用游戏拆包/解包资源。
- 《蛋仔派对》是网易游戏的注册商标，Windows 是微软公司的注册商标。
- 本项目与网易、微软无任何隶属或赞助关系。

## 项目维护者联系方式

- **GitHub**：[QiXiaoLight](https://github.com/QiXiaoLight)
- **哔哩哔哩**：[栖小光](https://space.bilibili.com/3690976851790561)、[WinNT-DWM-Sharp](https://space.bilibili.com/3706958846626741)
- **QQ 交流群**：[EggyUI交流群](https://qm.qq.com/q/DzX7VXZNMQ)
- **腾讯频道**：[EggyUISE](https://pd.qq.com/s/5ryka2vhl)

---

**祝您使用愉快！**