Assets\Realistic\Domestic Animals\Cats\Cat_male_Full\ contains a number of folders.
 - textures/ - the .tif texture files, used by materials.
 - Materials/ - the .mat material files.
 - fbx/ - the .fbx model/animation files, and the demo animation controller.
 - prefabs/ - the various prefab cats.

It also contains two scenes, 
 - Cat_Full_Demo_Scene.unity - A scene where it loops the animation for three cat variants (Cat_full_IP_c2, Cat_Fat_HighPoly_c7, Cat_LowPoly_c4).
 - Cat_Full_Object_Scene.unity - A non-animated scene showing all prefabs.

The Linus scene is instead under the base Assets/Scenes folder.

Textures:
=========
All textures are 4096x4096.
 - Cat_Metall - The metallicness map.How shiny each part is.
 - Cat_Normal - The normal map, giving extra 3D lighting information.
 - Cat_Color_Bl_Wt, Black with white tips
 - Cat_Color_Black
 - Cat_Color_Grey
 - Cat_Color_Orang, Ginger tabby
 - Cat_Color_Tiger, Grey/brown tabby
 - Cat_Color_White
 - Cat_Color_Wt_Bl, White with black face mark
 - *_m - Mobile versions of the textures. These exist for all images other than Car_Metall, and are identical to the regular versions, not rescaled or anything.
 - Linus_Color - Texture for Linus.
 - Linus_Normal - Normal map for Linus, includes height info for his fur detail.

Materials:
==========
There's one for each Cat_Color texture, the only difference being which texture they have selected, and that the _mobile variants use the "Mobile/Bumped Diffuse" shader, which uses only the regular and normal maps, rather than the "Standard" shader which also uses the metallic map.
 - Linus_Material is the material for Linus.

Fbx:
====
There are six files, one for each LOD+weight variant.

The cats are set up as "Generic" rather than "Humanoid" models.

Weight variants change the musculature of the cat:
 - Cat - slim cat.
 - Cat_Fat - a larger cat, but still within reasonable cat BMI.

LOD variants change the number of tris.
 - _LOD - Four LOD versions of the cat (LOD 0 to 3), rendered by Unity depending on distance. 
 - _HighPoly - Only the high-poly (LOD 0) version of the avatar.
 - _LowPoly - Only the low-poly (LOD 3) version of the avatar.

There is also an animation controller for the demo, but it's nothing complex: just loops through every possible animation in sequence.

There are also two subfolders,
 - IP_animations - has one file, Cat_full_IP.fbx, of "in place" anims (relative to world space), and Cat_Full_IP_Avatar.
 - RM_animations - has one file, Cat_full_RM.fbx, of "root motion" anims (relative to model's root bone), and Cat_Full_RM_Avatar.

Prefabs:
========
Skin variants change the cat texture from the Materials folder:
 - c1 - Cat_Color_BlackWhite, Black with white tips
 - c2 - Cat_Color_Black
 - c3 - Cat_Color_Grey
 - c4 - Cat_Color_Orange, Ginger tabby
 - c5 - Cat_Color_Tiger, Grey/brown tabby
 - c6 - Cat_Color_White
 - c7 - Cat_Color_WhiteBlack, White with black face mark
 - Linus - Linus_Material, Tabby and white

There are no mobile variants of prefabs.

There is one prefab for each combination of skin variants and LOD variant (Cat_LOD_c*, Cat_HighPoly_c*, Cat_LowPoly_c*, Cat_Fat_LOD_c*, Cat_Fat_HighPoly_c*, Cat_Fat_LowPoly_c*) as well as for each of IP and RM (Cat_full_IP_c* and Cat_full_RM_c*).

