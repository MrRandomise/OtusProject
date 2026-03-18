# 🧟 Zombie Wave Survivor — Выпускной проект OTUS

> **Курс:** Unity Game Developer · **Платформа:** [OTUS](https://otus.ru)  
> **Жанр:** Survival / Wave-Shooter  
> **Движок:** Unity 2022 LTS  
> **Язык:** C#

---

## 📖 О проекте

**Zombie Wave Survivor** — мобильная 3D-игра в жанре wave-shooter, созданная в качестве выпускного проекта курса Unity Game Developer на платформе OTUS.

Игрок управляет персонажем, который должен выживать против волн зомби, используя разное оружие, зарабатывать монеты с убитых врагов и тратить их в магазине между волнами.

### 🎮 Геймплей

- **Волновая система** — зомби атакуют волнами, сложность нарастает с каждым раундом
- **Несколько видов оружия** — каждое оружие обладает уникальными характеристиками и визуальным эффектом
- **Эффекты пуль** — кровотечение, замедление, мгновенная смерть, базовый урон
- **Магазин** — между волнами можно купить здоровье или новое оружие за монеты
- **Главное меню** — с кнопками новой игры и выхода
- **Game Over экран** — с возможностью перезапустить

---

## 🛠️ Технологии и архитектура

### Стек технологий

| Технология | Назначение |
|---|---|
| **Unity 2022 LTS** | Игровой движок |
| **C#** | Язык программирования |
| [Leopotam EcsLite](https://github.com/Leopotam/ecslite) | Entity Component System (ECS) |
| [Zenject](https://github.com/modesttree/Zenject) | Dependency Injection (DI) |
| **Unity Addressables** | Управление асетами |
| **Unity NavMesh AI** | Навигация зомби |
| **TextMeshPro** | UI-текст |
| **Joystick Pack** | Мобильный джойстик |

### Архитектурные паттерны

```
📦 OtusProject
 ├── 🎮 Assets/Game/            — Игровая логика
 │   ├── ECS/                   — ECS-системы и компоненты
 │   │   ├── Components/        — Данные сущностей (Health, Speed, Tags…)
 │   │   ├── Systems/           — Логика обработки (Damage, Death, Move…)
 │   │   └── EcsStartup.cs      — Инициализация ECS-мира
 │   ├── GameSystem/            — Игровые подсистемы
 │   │   ├── Bullet/            — Пули и их эффекты
 │   │   ├── Character/         — Персонаж игрока
 │   │   ├── Zombie/            — Зомби
 │   │   ├── Waves/             — Правила волн
 │   │   ├── Pools/             — Пулы объектов
 │   │   └── Weapon/            — Система оружия
 │   ├── GameUI/                — UI (MVP — Presenter + View)
 │   └── DI/                    — Zenject-инсталлеры
 │
 └── 🧩 Assets/Modules/         — Переиспользуемые модули
     ├── Wave/                  — Система волн
     ├── Shop/                  — Магазин
     ├── Weapon/                — Хранилище оружия
     ├── Pools/                 — Базовый пул объектов
     ├── Input/                 — Менеджер ввода
     ├── MapLoader/             — Загрузка карт
     ├── GameResources/         — Ресурсы (монеты)
     └── UI/                    — UI-компоненты магазина
```

### Ключевые паттерны

- **ECS (Entity Component System)** — вся игровая логика (движение, урон, смерть, AI зомби) реализована через ECS-системы Leopotam EcsLite
- **Dependency Injection** — Zenject используется для инверсии зависимостей между всеми подсистемами
- **Object Pooling** — пулы для пуль, зомби и ресурсов, чтобы избежать лишнего GC
- **MVP (Model-View-Presenter)** — UI-слой разделён на View и Presenter
- **Observer / Events** — события для связи ECS-мира с MonoBehaviour-объектами
- **ScriptableObject Config** — настройки зомби, пуль, оружия и ресурсов вынесены в конфиги

---

## 🎯 Реализованный функционал

### Игровые системы (ECS)

| Система | Описание |
|---|---|
| `DeathSystem` | Обработка смерти сущностей |
| `DamageSystem` | Нанесение урона |
| `ZombieAttackSystem` | Атака зомби |
| `MoviementSystem` | Движение персонажа |
| `NavMashSystem` | NavMesh-навигация зомби |
| `RotateCharacterSystem` | Поворот персонажа к курсору/пальцу |
| `SlowingEffectSystem` | Эффект замедления |
| `BleendingEffectSystem` | Эффект кровотечения |
| `TakeBulletEffectsSystem` | Применение эффектов пуль |
| `LifeTimerSystem` | Таймер жизни сущности (пули, тела) |
| `DropSystem` | Выпадение лута |

### Эффекты пуль

| Эффект | Описание |
|---|---|
| `BasicDamageEffects` | Базовый урон |
| `BleedingEffects` | Кровотечение (урон в секунду N секунд) |
| `SlowingEffects` | Замедление передвижения |
| `InstaDeadEffects` | Мгновенная смерть |

### UI-презентеры

- `HealthPresenter` — полоска здоровья игрока
- `WaveViewPresenter` / `WaveMessagePresenter` — номер волны и сообщения
- `KillZombiePresenter` — счётчик убитых зомби
- `ResourcePresenter` — количество монет
- `ShopPresenter` / `ShowHideShopPresenter` — управление магазином
- `WeaponViewPresenter` / `WeaponStoragePresenter` — отображение оружия
- `ZombieHealthBarPresenter` — здоровье зомби над головой

---

## 🚀 Запуск проекта

### Требования

- Unity **2022.3 LTS** (или выше)
- Git LFS (для больших файлов асетов)

### Шаги

1. Клонировать репозиторий:
   ```bash
   git clone https://github.com/MrRandomise/OtusProject.git
   ```

2. Открыть проект в **Unity Hub → Open Project**

3. Дождаться импорта асетов и компиляции пакетов

4. Открыть сцену `Assets/Scenes/MainMenuScene.unity`

5. Нажать **Play** ▶️

> **Примечание:** Для мобильной сборки выбрать платформу **Android** в Build Settings и настроить Addressables для Android (уже есть в `Assets/AddressableAssetsData/Android/`).

---

## 📂 Структура проекта

```
OtusProject/
├── Assets/
│   ├── Fonts/               — Шрифты (chicken_butt_rus)
│   ├── Game/                — Основная игровая логика
│   ├── Modules/             — Переиспользуемые модули
│   ├── Pack/                — Сторонние ассет-паки
│   │   ├── ToonyTinyPeople  — 3D-персонажи
│   │   ├── SimpleNaturePack — Природное окружение
│   │   ├── Joystick Pack    — Мобильный джойстик
│   │   ├── TinyUIKit        — UI-компоненты
│   │   └── cemetery halloween set — Окружение кладбища
│   ├── Plugins/             — Сторонние плагины (Zenject, EcsLite…)
│   ├── Resources/           — ProjectContext (Zenject)
│   ├── Scenes/
│   │   ├── MainMenuScene    — Главное меню
│   │   └── GameScene        — Основная игровая сцена
│   └── TextMesh Pro/        — TextMeshPro-ресурсы
├── Packages/                — Unity Package Manager
└── ProjectSettings/         — Настройки проекта
```

---

## 👨‍💻 Чему научился в процессе разработки

- Проектирование игры на **ECS-архитектуре** с разделением данных и логики
- Применение **Dependency Injection** (Zenject) в игровом проекте
- Работа с **Unity Addressables** для оптимизации загрузки ресурсов
- Реализация **Object Pooling** для снижения нагрузки на GC
- Построение UI на паттерне **MVP**
- Настройка **NavMesh AI** для автономной навигации NPC
- Организация **модульной структуры** проекта

---

## 📬 Контакты

Если вас заинтересовал проект или вы хотите обсудить детали реализации — буду рад пообщаться!

[![GitHub](https://img.shields.io/badge/GitHub-MrRandomise-181717?logo=github)](https://github.com/MrRandomise)

---

*Проект разработан в рамках курса **Unity Game Developer** на платформе [OTUS](https://otus.ru).*
