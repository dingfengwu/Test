/// <reference path="npm/lib/util.js" />
/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    path = require("path"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    htmlmin = require("gulp-htmlmin"),
    opt = require("./npm/config.json"),
    util = require("./npm/lib/util"),
    covertTo = require('./npm/lib/covertTo')
    ;

var paths = {
    webroot: "./wwwroot/",
    source: "./wwwroot/html/source/",
    htmldir: "./wwwroot/html/",
    cssdir: "./wwwroot/css/",
    jsdir:"./wwwroot/js/"
};

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.html = paths.webroot + "html/**/*.html";
paths.minHtml = paths.webroot + "html/**/*.min.html";
paths.md = paths.webroot + "html/source/**/*.md";

paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";
paths.concatHtmlDest = paths.webroot + "html/*.min.css";

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean:html", function (cb) {
    rimraf(paths.concatHtmlDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css", "clean:html"]);

gulp.task("min:js", function () {
    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(".");
});

gulp.task("min:css", function () {
    return gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(".");
});

gulp.task("min:html", function () {
    return gulp.src([paths.html, "!" + paths.minHtml])
        .pipe(concat(paths.concatHtmlDest))
        .pipe(htmlmin())
        .pipe(".");
});

gulp.task('md',function () {
    var latest = util.getNewestFile(paths.source, ".md");
    opt.lastModify = latest.LatestTime;

    return gulp.src(paths.md)
		.pipe(covertTo("template", opt.theme))
		.pipe(util.jade({
		    basedir: path.resolve('./npm/'),
		    locals: opt,
		    pretty: true
		}))
		.pipe(gulp.dest(paths.htmldir));
});

gulp.task("min", ["md", "min:js", "min:css", 'min:html']);

