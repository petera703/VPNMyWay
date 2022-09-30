# VPNMyWay

This is the source code for VPNMyWay, a little app that provides one-click control of your Windows VPN from an icon in your system tray, and automatic reconnect if your VPN connection drops. 

I wrote this in 2015 for my own sanity, as I was finding the standard Windows behaviour and UI interactions somewhat lacking when it came to VPNs. I had a bit of fun writing it, and it did the job for me; I'm happy if others find it helpful too.

# Future development

It's unlikely I'll have time to update VPNMyWay any more. Additionally as of October 2022 I am currently in hosptal in an extended recovery period of some months. But I will be following things here when I can from time to time.

# Windows 11+

VPNMyWay works with Windows versions up to Windows 10. Myself I have no plans yet to use Windows 11 for anything until we know more about what it breaks. If you want to make VPNMyWay work with Windows 11, I am not able to help with that but I guess you should be able to do it.

# Notes on DotRas

VPNMyWay uses DotRas.dll to access your Windows VPN connections (kudos to jeff-winn of winnster for making DotRas freely available). It was originally developed against DotRas version 1.3 in 2015, when DotRas was available on CodePlex under the GNU Lesser General Public License Version 2.1, February 1999. The GNU licence wording was included in the CodePlex download as License.rtf. For details, see Licence.rtf in the DotRas folder. Under the terms of the GNU licence, VPNMyWay only "uses the library", rather than being a "derivative work of the library", and is thus outside the scope of the GNU licence. The relevant section is reproduced below from Dotras/Licence.rtf:

> 5. A program that contains no derivative of any portion of the Library, but is designed to work with the Library by being compiled or linked with it, is called a "work that uses the Library". Such a work, in isolation, is not a derivative work of the Library, and therefore falls outside the scope of this License.

If you use VPNMyWay with any other version of DotRas, you should check the licensing implications (if any) of doing so. DotRas has now moved to GitHub (https://github.com/winnster/DotRas) where it is licenced under the GNU General Public License v3.0. The source for version 1 has also moved to GitHub (https://github.com/winnster/DotRas-V1).

# Visual Studio solution 

VPNMyWay is written in C#. In addition to the VPNMyWay project, the solution also contains a setup project (.vdproj). As this type of setup project is no longer natively supported by Visual Studio, you'll need to install [the extension](https://marketplace.visualstudio.com/items?itemName=VisualStudioClient.MicrosoftVisualStudio2017InstallerProjects) before Visual Studio will recognize the .vdproj project type. Alternatively, if you have no need to build the MSI, you can simply remove the setup project from the solution when VS complains about the unsupported project type.

Other than that, you'll just need to repair the DotRas dll reference to point to the file in the DotRas folder, and set your debug command-line arguments in Visual Studio to at least identify your VPN name (for example, adding the two arguments `MYVPN /manualfirstconnect` would be a good starting point), and you should be good to go. If you don't use the MSI installer, you'll need to create a shortcut for starting VPNMyWay with whatever command-line arguments you want to use. The available command-line options are explained [in the FAQ on the WordPress site](https://vpnmyway.wordpress.com/faq/).
