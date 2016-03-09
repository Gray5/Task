/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/

module.exports = function (grunt) {
    grunt.initConfig({
        nggettext_extract: {
            pot: {
                options: {
                    extensions: {
                        htm: 'html',
                        html: 'html',
                        php: 'html',
                        phtml: 'html',
                        tml: 'html',
                        js: 'js',
                        cshtml: 'html'
                    },
                },
                files: {
                    'po/template.pot': ['views/home/*.cshtml']
                }
            },
        },

        nggettext_compile: {
            all: {
                files: {
                    'wwwwroot/js/translations.js': ['po/*.po']
                }
            },
        },
    });

    grunt.loadNpmTasks('grunt-angular-gettext');

    grunt.registerTask('default', ['nggettext_extract', 'nggettext_compile']);
};