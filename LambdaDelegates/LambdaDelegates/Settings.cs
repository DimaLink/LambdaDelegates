using System;

namespace LambdaDelegates
{
     
    static class Settings
    {
        public const int WIDTH = 80;
        public const int HEIGHT = 25;

        public const int SPACE_WIDTH = 78;
        public const int SPACE_HEIGHT = 17;

        public const char CHAR_CURSOR = 'У';

        public const int SETTING_X_LEFT = 2;
        public const int SETTING_X_RIGHT = SPACE_WIDTH - 2;
        public const int SETTING_Y_UP = 2;
        public const int SETTING_Y_DOWN = SPACE_HEIGHT -2;


        public const char SELECTED_INDEX_CHAR = '*';
        public const char NOT_SELECTED_INDEX_CHAR = ' ';

        /*курсор и объекты все в своих относительных измерениях.*/

    }

}