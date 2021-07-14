# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.1.1] - 2021-07-15
### Fixed
- Fixed the asmdef target platform and update dependent package

## [0.1.0] - 2021-07-02
### Added
- A UIPanelChild class for all the children in a panel to get access to the panel itself.
- Added IUIStackEventInvoker interface for UI element invoke finish event.
  This can trigger the finish action in the panel and release the hold in UI Stack Operation.
- Added UIStackListener for the panel to listen the event invoked from UI elements.
- AsyncPop and AsyncPause method for UIStackManager.
  When using these two methods to Pause or Pop,
  the new panel will not resume or push until the old panel finish all the operations.

### Removed
- Removed the inherit way of creating a UIPanelElement logic.
  Instead, now use the UIPanelElement it self to implement logic.

### Fixed
- Check if the panel is null when resume, solve the null reference error.

## [0.0.3] - 2021-06-30
### Fixed
- Added Assembly Definition

## [0.0.2] - 2021-06-30
### Added
- Finish LICENSE

### Changed
- Changed the required Unity version in package.json

## [0.0.1] - 2021-06-29
### Added
- Initialize the UI Stack System Repository.
- Added UnityEvent to the UIPanelElement base class.
Developers can use it to handle panel logic.

[Unreleased]: https://github.com/Fangjun-Zhou/Unity-UI-Stack-System
[0.1.1]: https://github.com/Fangjun-Zhou/Unity-UI-Stack-System/releases/tag/uistacksystem-0.1.1
[0.1.0]: https://github.com/Fangjun-Zhou/Unity-UI-Stack-System/releases/tag/uistacksystem-0.1.0
[0.0.3]: https://github.com/Fangjun-Zhou/Unity-UI-Stack-System/releases/tag/uistacksystem-0.0.3
[0.0.2]: https://github.com/Fangjun-Zhou/Unity-UI-Stack-System/releases/tag/uistacksystem-0.0.2
[0.0.1]: https://github.com/Fangjun-Zhou/Unity-UI-Stack-System/releases/tag/uistacksystem-0.0.1