# Gammashine💛 (0.4.5v)
## GAM Gen2

### [🟡🟡🟡⚫⚫⚫⚫⚫]% - Before the release of 1.0.0v  
### [🟡⚫⚫⚫⚫⚫⚫⚫]% - Before the release of GAM Gen 3  
### [🟡🟡⚫⚫⚫⚫⚫⚫]% - XML documentation    

❗This library is of an amateur level and is made for myself and for my needs, but I openly share my work and maybe someone will like my concept of working with video games

💛 Feline library for Unity. GAM - Modular system architecture and many other features 

What does it include?

⭐) GAM Gen2 (Gen 3 in development) - Gamma architecture modular. The basic concept consists of the fact that everything is based on independent modules with wide functionality and consists of 5 pillars for building the entire project.

0) RulecoreSupremind - It is essentially a regular system (mastermind), but it is a bit offshoot and allows you to play other systems. It also automatically allows you to save a little bit of performance due to the only working MonoBehaviour in the project. Although it should be noted that he is not the only MonoBehaviour by himself.
1) Data - GAM uses the concept that data goes separately and can be manipulated and synchronized between different modules and systems using ready-made data for this. There is also a clear separation of what data is being done:
- Dataset - data for the operation of specific modules.
- Unite - Data that is explicitly specified in order to synchronize them and is an addition for the operation of specific modules.
- Gathering - data that explicitly indicates that it is intended to transfer certain data to other modules and does not affect the operation of the module in any way.
2) Module - Is the main unit of the system that does all the work. The basic concept is the state. Modules can be turned on and off, thereby changing the processing logic on the go and at the same time increasing productivity due to the fact that conditionally about 40% of all modules in the project are processed in time (as an example). All of them are inherited from the IModulableMarkout interface, which in turn has the main IModulable interface after it. From it come the main implementations of IUniversalModulable and IPlayableModulable.
3) Collector - Are an intermediate link between the modules and the system in which they will work. It stores all the data and modules for the operation of the system. It also has methods for collecting, destroying, turning modules on and off.
4) Mastermind - Is, as such, a system in which the logic of specific modules and their logic of switching on and off are located. Here, data and data classes are synchronized, the only ones that are inherited from MonoBehaviour, but only so that Unity considers them as separate objects under the hood and the ability to set the parameters of these modules in the inspector.
5) Controllable - Is the second half of the basis for building projects on GAM. This is an enum, but with the help of their processing, we can specify the state and synchronize data "at our fingertips" bypassing a more crude way of synchronizing data (although this is not possible everywhere at the moment).
6) Origamma - this type of classes is such a classic representation of them, where the whole concept of modules, data and systems are combined into one whole. Consider this as your own evolution of systems that have fixed functionality.

❗Gammashine has detailed XML documentation in order not to look into third-party resources.

⭐ The library not only has a foundation for building systems, but also ready-made data, modules and masterminds. For example, it has an extensive set of Origamma, which have fixed functionality for various jobs. For example:

- Timedata - An extensive class for working with a timer.
- Autodata - Class that automatically changes values depending on the state (5️ Controllable).
- Various collections and other "machines" - such as VEngine (visual debugging) and others.
