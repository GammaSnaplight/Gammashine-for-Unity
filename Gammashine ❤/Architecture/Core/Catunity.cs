// Документирование имени пространство имен
namespace Snaplight.Catunity { } // Основные классы
namespace Snaplight.Catunity.Modules { } // Основные модули
namespace Snaplight.Catunity.GammaModulesEX { } // Класс с методами расширения моей библиотеки
namespace Snaplight.Catunity.Extension { } // Классы с методами расширения
namespace Snaplight.Catunity.Experimental { } // Класс с эксперементальными функциями
namespace Snaplight.Catunity.Debug { } // Класс с вспомогательными методами
namespace Snaplight.Catunity.Debug.Editor { } // Класс для отслеживания в редакторе Unity
namespace Snaplight.Catunity.Alien { } // Классы использующие библиотеки вне .NET, Unity, Snaplight


/// <summary>
/// Пространство имен - <see cref="Snaplight.Catunity"/> является библиотекой созданной сообществом -
/// <see cref="GammaSnaplight"/>.
/// <code>
/// СПРАВКА ОБ ПРАВОПИСАНИИ КОДА:
///  <see href="public"/> поля именуются через большую букву - Field (Speed, HpEnemy)
///  <see href="internal"/> поля именуются через маленькую букву - field (speed, hpEnemy)
///  <see href="private"/> поля именуются через маленькую букву с нижним слэшем - _field (_speed, _hpEnemy)
///  <see href="protected"/> поля имеют префикс - _Field (_Speed, _HpEnemy) 
///  <see href="interface"/> интерфейсы имеют префикс - I (IDamageble, IMath) 
///  <see href="abstract"/> классы помечаются как - AbsClass (AbsPlayer, AbsEnemy) 
///  <see href="extension-method"/> методы расширения окончание Ex - MethodEx (SumEx, AnimatorEx) 
///  <see href="enum"/> типы желательно выделять послесловием - Type, Mode и т.д. (OptionsType, SafeMode)
///  <see href="property"/> свойства именуются через большую букву
///  
/// РЕКОМЕНДАЦИИ:
///  <see href="J3Ws (just3words)"/> - я стараюсь придерживаться правила именование не больше 3 слов где либо
///  <see href="KISS"/> - читабельность > простота > производительность
///  <see href="EliminateBicycle"/> - не повторять, а расширять. То есть не повторять реализацию уже существующих методов, если только ваша реалиазиция лучше повторяемой
///
/// ВНИМАНИЕ!
///  В своих реализациях можно использовать только внутрение библиотеки <see cref="System"/>, <see cref="Unity"/>, а также <see cref="Snaplight"/>.
///  Все классы использующие сторонние библиотеки помещаются в пространство имен <see cref="Snaplight.Catunity.Alien"/>.
///  
///  И САМОЕ ГЛАВНОЕ! Делайте документацию XML настолько понятной, насколько это возможно.
/// </code>
/// </summary>
sealed class Catunity { }