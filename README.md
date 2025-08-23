# UCB Build Number

For Unity Cloud builds, this package will automatically set the build
number (iOS) and bundle version code (Android) to the build number
used by the Unity Cloud Build service.

This ensures that every build gets a fresh, auto incrementing build number,
and having the numbers in sync with UCB makes troubleshooting easier.
