cmake_minimum_required(VERSION 3.10)

project(app VERSION 1.0)

add_subdirectory(boolinq)
add_subdirectory(Funcs)

add_executable(app main.cxx)

configure_file(appConfig.h.in appConfig.h)

target_include_directories(app PUBLIC
                "${PROJECT_BINARY_DIR}"
                "${PROJECT_BINARY_DIR}/things/boolinq"
                "${PROJECT_BINARY_DIR}/boolinq"
                "${PROJECT_BINARY_DIR}/things/Funcs"
                "${PROJECT_BINARY_DIR}/Funcs"
)

target_link_libraries(app PUBLIC boolinq Funcs)

set_target_properties(boolinq PROPERTIES LINKER_LANGUAGE CXX)
set_target_properties(Funcs PROPERTIES LINKER_LANGUAGE CXX)

set(CMAKE_CXX_STANDARD 11)
set(CMAKE_CXX_STANDARD_REQUIRED 11)